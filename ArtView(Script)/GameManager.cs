using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 1) ���� �������� �÷����� ���� �ڵ����� ������ ������Ʈ�� ���ִ� ���
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
         * ��ó���� (preprocessor)
         * ������ ������ ����Ǵ� �ڵ�
         * 
         * # ��ȣ�� �ٿ��� ���
         * - �÷��� ���� ������
         */

#if UNITY_EDITOR // ����Ƽ ������ ������ ��
        eventSystem_Editor.SetActive(true);

        if (SceneManager.GetActiveScene().name == "1 Art")
        {
            GameObject mainCamera = GameObject.Find("CenterEyeAnchor");
            mainCamera.transform.localPosition = editorCameraPosition;
        }

#elif UNITY_ANDROID // �ȵ���̵� ������ ��
        eventSystem_VR.SetActive(true);

#endif
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
