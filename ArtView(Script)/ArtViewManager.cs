using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class ArtViewManager : MonoBehaviour
{
    [Header("Main Panel - Objects")]
    public GameObject[] highlightBtns;
    public GameObject[] objs;

    [Header("Sub Panel - Home")]
    public Button Homebtn;
    public GameObject highlightHomebtn;

    [Header("Sub Panel = Play")]
    public Button Playbtn;
    public GameObject highlightPlaybtn;
    public Image PlayImg;
    public Sprite playIcon;
    public Sprite pauseIcon;
    bool isPlay = false;        // 플레이 중인지의 여부
    float time;                 // 현재 오브젝트의 플레이된 시간
    float playDelayTime = 5.0f; // 다음 오브덱트로 넘어가는 시간
    int playindex = 0;          // 현재 오브젝트의 index

    [Header("Sub Panel - Volume")]
    public GameObject highlightVolumebtn;
    public Image volumeImg;
    public Sprite volumeOnIcon;
    public Sprite volumeOffIcon;
    bool isVolumeOn = true;

    [Header("Sub Panel - Rotate")]
    public GameObject highlightRotateBtn;
    bool isRotate = false;
    float RotateSpeed = 0.15f;

    [Header("Sub Panel - Light")]
    public GameObject highlightLightBtn;            // 메인 Light 버튼 하이라이트
    public GAui lightPanel;                         // 12가지 색상 Light 패널
    public Image lightImg;                          // 메인 Light 버튼 아이콘
    public Light mainLight;                         // Light 컴포넌트
    public Color[] lightColors;                     // 12가지 색상 값
    public GameObject[] highlightSelectLightBtns;   // 12가지 색상 Light 버튼 하이라이트
    bool isLight = true;                            // 라이트 활성화 여부
    bool isLightPanelOn = false;                    // Light 패널 활성화 여부
    int lightindex = 11;                            // 12가지 중 선택된 Light index

    // Start is called before the first frame update
    void Start()
    {
        ShowObj(0); // 처음 시작시 0번째 오브젝트 활성화 
        PressSelectLightBtn(11); // 11번째 Light로 색상으로 시작하기
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotate)
        {
            // 현재 선택된 objs를 월드 좌표계 기준으로 rotateSpeed만큼 y축 회전한다.
            objs[playindex].transform.Rotate(new Vector3(0, RotateSpeed), Space.World);
        }
        // Play 버튼이 눌려있을 때 동작
        if (isPlay)
        {
            // 매 프레임마다 현재 진행된 시간을 저장
            time += Time.deltaTime;

            // time 값이 5 초 이상이 되면
            if(time>playDelayTime)
            {
                time = 0;
                // 1) playindex를 1씩 올려줌
                playindex++;
                if (playindex >= objs.Length) playindex = 0;
                // 2) 다음 오브젝트 Showobj;
                ShowObj(playindex);
                AudioManager.instance.PlayClickSound();
            }
        }
    }

    public void ShowObj(int index)
    {
        // 1) 모든 버튼의 선택색상 블랙
        foreach( GameObject b in highlightBtns) b.SetActive(false);
        // 2) 모든 오브젝트들 비활성화
        foreach (GameObject o in objs) o.SetActive(false);

        // 3) 해당 버튼의 선택색상 파랑
        highlightBtns[index].SetActive(true);
        // 4) 해당 오브젝트 활성화
        objs[index].SetActive(true);
        // 5) index 갱신
        playindex = index;
    }

    public void PressHomebtn()
    {
        StartCoroutine(OnHomebtn());
    }

    IEnumerator OnHomebtn()
    {
        highlightHomebtn.SetActive(true);
        //homeBtn.interactable = false;

        yield return new WaitForSeconds(1.0f);

        highlightHomebtn.SetActive(false);

        GameManager.instance.NextScene("01.Lobby");
    }

    public void PressPleybtn()
    {
        StartCoroutine(OnPlaybtn());
    }

    // 자동으로 다음 오브젝트를 showObj() 해주는 기능
    IEnumerator OnPlaybtn()
    {
        if (isPlay)
        {
            isPlay = false;
            PlayImg.sprite = playIcon;
        }
        else
        {
            isPlay = true;
            PlayImg.sprite = pauseIcon;
        }

        highlightPlaybtn.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        highlightPlaybtn.SetActive(false);
    }

    public void PressVolumebtn()
    {
        StartCoroutine(OnVolumebtn());
    }

    IEnumerator OnVolumebtn()
    {
        if(isVolumeOn)
        {
            isVolumeOn = false;
            volumeImg.sprite = volumeOffIcon;
            AudioManager.instance.Setvolume(0);
        }
        else
        {
            isVolumeOn = true;
            volumeImg.sprite = volumeOnIcon;
            AudioManager.instance.Setvolume(1);
        }

        highlightVolumebtn.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        highlightVolumebtn.SetActive(false);
    }

    public void PressRotateBtn()
    {
        StartCoroutine(OnRotateBtn());
    }

    IEnumerator OnRotateBtn()
    {
        if (isRotate) isRotate = false;
        else isRotate = true;

        highlightRotateBtn.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        highlightRotateBtn.SetActive(false);
    }

    public void PressLightBtn()
    {
        StartCoroutine(OnLightBtn());
    }

    IEnumerator OnLightBtn()
    {
        // 1) OFF
        if(!isLight)
        {
            isLight = true;
            // 환경 조명 모드 : Custom
            RenderSettings.ambientMode = AmbientMode.Custom;
            RenderSettings.ambientLight = lightColors[lightindex];
            // Directional 조명 색상
            mainLight.color = lightColors[lightindex];
            // light 버튼 색상
            lightImg.color = lightColors[lightindex];
        }
        // 2) ON
        else if(isLight&&!isLightPanelOn)
        {
            isLightPanelOn = true;
            AnimationManager.instance.OnPanel(lightPanel, null);
        }
        // 3) COLOR
        else
        {
            isLight = false;
            isLightPanelOn = false;
            AnimationManager.instance.OffPanel(lightPanel, null);
            // 환경 조명 모드 : Skybox
            RenderSettings.ambientMode = AmbientMode.Skybox;
            // Diractional 조명 색상
            mainLight.color = Color.black;
            // light 버튼 색상
            lightImg.color = Color.gray;
        }

        highlightLightBtn.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        highlightLightBtn.SetActive(false);
    }

    public void PressSelectLightBtn(int index)
    {
        lightindex = index;

        foreach (GameObject o in highlightSelectLightBtns) o.SetActive(false);
        highlightSelectLightBtns[index].SetActive(true);

        RenderSettings.ambientLight = lightColors[lightindex];
        // Directional 조명 색상
        mainLight.color = lightColors[lightindex];
        // Light 버튼 색상
        lightImg.color = lightColors[lightindex];
    }
}
