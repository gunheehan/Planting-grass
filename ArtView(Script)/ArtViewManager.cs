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
    bool isPlay = false;        // �÷��� �������� ����
    float time;                 // ���� ������Ʈ�� �÷��̵� �ð�
    float playDelayTime = 5.0f; // ���� ���굦Ʈ�� �Ѿ�� �ð�
    int playindex = 0;          // ���� ������Ʈ�� index

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
    public GameObject highlightLightBtn;            // ���� Light ��ư ���̶���Ʈ
    public GAui lightPanel;                         // 12���� ���� Light �г�
    public Image lightImg;                          // ���� Light ��ư ������
    public Light mainLight;                         // Light ������Ʈ
    public Color[] lightColors;                     // 12���� ���� ��
    public GameObject[] highlightSelectLightBtns;   // 12���� ���� Light ��ư ���̶���Ʈ
    bool isLight = true;                            // ����Ʈ Ȱ��ȭ ����
    bool isLightPanelOn = false;                    // Light �г� Ȱ��ȭ ����
    int lightindex = 11;                            // 12���� �� ���õ� Light index

    // Start is called before the first frame update
    void Start()
    {
        ShowObj(0); // ó�� ���۽� 0��° ������Ʈ Ȱ��ȭ 
        PressSelectLightBtn(11); // 11��° Light�� �������� �����ϱ�
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotate)
        {
            // ���� ���õ� objs�� ���� ��ǥ�� �������� rotateSpeed��ŭ y�� ȸ���Ѵ�.
            objs[playindex].transform.Rotate(new Vector3(0, RotateSpeed), Space.World);
        }
        // Play ��ư�� �������� �� ����
        if (isPlay)
        {
            // �� �����Ӹ��� ���� ����� �ð��� ����
            time += Time.deltaTime;

            // time ���� 5 �� �̻��� �Ǹ�
            if(time>playDelayTime)
            {
                time = 0;
                // 1) playindex�� 1�� �÷���
                playindex++;
                if (playindex >= objs.Length) playindex = 0;
                // 2) ���� ������Ʈ Showobj;
                ShowObj(playindex);
                AudioManager.instance.PlayClickSound();
            }
        }
    }

    public void ShowObj(int index)
    {
        // 1) ��� ��ư�� ���û��� ��
        foreach( GameObject b in highlightBtns) b.SetActive(false);
        // 2) ��� ������Ʈ�� ��Ȱ��ȭ
        foreach (GameObject o in objs) o.SetActive(false);

        // 3) �ش� ��ư�� ���û��� �Ķ�
        highlightBtns[index].SetActive(true);
        // 4) �ش� ������Ʈ Ȱ��ȭ
        objs[index].SetActive(true);
        // 5) index ����
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

    // �ڵ����� ���� ������Ʈ�� showObj() ���ִ� ���
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
            // ȯ�� ���� ��� : Custom
            RenderSettings.ambientMode = AmbientMode.Custom;
            RenderSettings.ambientLight = lightColors[lightindex];
            // Directional ���� ����
            mainLight.color = lightColors[lightindex];
            // light ��ư ����
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
            // ȯ�� ���� ��� : Skybox
            RenderSettings.ambientMode = AmbientMode.Skybox;
            // Diractional ���� ����
            mainLight.color = Color.black;
            // light ��ư ����
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
        // Directional ���� ����
        mainLight.color = lightColors[lightindex];
        // Light ��ư ����
        lightImg.color = lightColors[lightindex];
    }
}
