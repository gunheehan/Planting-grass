using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeout_controller : MonoBehaviour
{
    public float time;          // 주어진 시간
    public Text timeText;       // 현재 시간 출력
    public float currenTime;    // 현재 시간
    public GameObject floor;    // 게임 오버시 비활성화할 바닥
    public GameObject[] ceilling; // 게임 오버시 비활성화할 천장

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
