using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationManager : MonoBehaviour
{
    private static AnimationManager _instance;
    
    public static AnimationManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AnimationManager>();
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<AnimationManager>();
        }
    }
    // 해당 패널을 Movein() - 애니메이션 실행
    IEnumerator OnAnimation(GAui gaui, Action action)
    {
        // 1초 딜레이
        yield return new WaitForSeconds(1.0f);

        // 해당 gaui 애니메이션 실행
        gaui.MoveIn(GSui.eGUIMove.SelfAndChildren);

        // 해당 gaui의 Raycast 비활성화
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, false);

        // 애니메이션 동작 시간(2초) 동안 딜레이
        yield return new WaitForSeconds(2.0f);

        // action에 저장된 함수가 있다면 실행
        if (action != null) action();

        // 해당 guai의 Raycast 활성화
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, true);
    }
    // 해당 패널을 MoveOut - 애니메이션 종료
    IEnumerator OffAnimation(GAui gaui, Action action)
    {
        // 해당 gaui 애니메이션 종료
        gaui.MoveOut(GSui.eGUIMove.SelfAndChildren);

        // 해당 gaui의 Raycast 비활성화
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, false);

        // 애니메이션 동작 시간(2.5초) 동안 딜레이
        yield return new WaitForSeconds(2.5f);

        // action에 저장된 함수가 있다면 실행
        if (action != null) action();

        // 해당 guai의 Raycast 활성화
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, true);
    }
    public void OnPanel(GAui gaui, Action action)
    {
        StartCoroutine(OnAnimation(gaui, action));
    }

    public void OffPanel(GAui gaui, Action action)
    {
        StartCoroutine(OffAnimation(gaui, action));
    }
}
