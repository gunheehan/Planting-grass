using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeout_controller : MonoBehaviour
{
    public float time;          // �־��� �ð�
    public Text timeText;       // ���� �ð� ���
    public float currenTime;    // ���� �ð�
    public GameObject floor;    // ���� ������ ��Ȱ��ȭ�� �ٴ�
    public GameObject[] ceilling; // ���� ������ ��Ȱ��ȭ�� õ��

    // Start is called before the first frame update
    void Start()
    {
        time = 300f;
        currenTime = time;
        GameManager.instance.isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        currenTime -= Time.deltaTime;

        if(currenTime<=0)
        {
            GameManager.instance.isGameOver = true;
            Lose();
        }
        UpdateTimeText();
    }
    void Lose()
    {
        floor.SetActive(false);
        foreach (GameObject o in ceilling) o.SetActive(false);
    }

    void UpdateTimeText()
    {
        int curTime = (int)currenTime;
        timeText.text = ((curTime / 60 < 10)
            ? "0" + (curTime / 60).ToString()
            : (curTime / 60).ToString())
            + ":"
            + (((curTime % 60 < 10)
            ? "0" + (curTime % 60).ToString()
            : (curTime % 60).ToString()));
    }
}
