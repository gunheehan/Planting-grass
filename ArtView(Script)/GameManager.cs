using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 1) 현재 실행중인 플랫폼에 따라 자동으로 지정된 오브젝트를 켜주는 기능
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    GameObject eventSystem_Editor;
    GameObject eventSystem_VR;

    Vector3 editorCameraPosition = new Vector3(0.22f, 0.1f, -0.11f);

    void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<GameManager>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        eventSystem_Editor = GameObject.Find("EventSystem");
        eventSystem_VR = GameObject.Find("UIHelpers");

        if (eventSystem_Editor != null) eventSystem_Editor.SetActive(false);
        if (eventSystem_VR != null) eventSystem_VR.SetActive(false);

        /*
         * 전처리기 (preprocessor)
         * 컴파일 이전에 실행되는 코드
         * 
         * # 기호를 붙여서 사용
         * - 플랫폼 의존 컴파일
         */

#if UNITY_EDITOR // 유니티 에디터 상태일 때
        eventSystem_Editor.SetActive(true);

        if (SceneManager.GetActiveScene().name == "1 Art")
        {
            GameObject mainCamera = GameObject.Find("CenterEyeAnchor");
            mainCamera.transform.localPosition = editorCameraPosition;
        }

#elif UNITY_ANDROID // 안드로이드 상태일 때
        eventSystem_VR.SetActive(true);

#endif
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
