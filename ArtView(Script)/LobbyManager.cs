using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GAui button1;
    public GAui button2;
    void Start()
    {
        AnimationManager.instance.OnPanel(button1, null);
        AnimationManager.instance.OnPanel(button2, null);
    }
    // 버튼을 누를때 index 1, 2
    public void PressButton(int buttonindex)
    {
        Action action = null;

        switch(buttonindex)
        {
            case 1:
                // 1 Art 씬으로 전화하는 함수를 추가
                action += () => GameManager.instance.NextScene("1 Art");
                AnimationManager.instance.OffPanel(button1, action);
                AnimationManager.instance.OffPanel(button1, null);
                break;
            case 2:
                // 2 Map 씬으로 전화하는 함수를 추가
                //action += () => NextScene("2 Map");
                AnimationManager.instance.OffPanel(button2, null);
                AnimationManager.instance.OffPanel(button2, action);
                break;
            default:
                print("index가 맞지 않습니다.");
                break;
        }
    }
}
