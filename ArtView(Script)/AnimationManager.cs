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
    // �ش� �г��� Movein() - �ִϸ��̼� ����
    IEnumerator OnAnimation(GAui gaui, Action action)
    {
        // 1�� ������
        yield return new WaitForSeconds(1.0f);

        // �ش� gaui �ִϸ��̼� ����
        gaui.MoveIn(GSui.eGUIMove.SelfAndChildren);

        // �ش� gaui�� Raycast ��Ȱ��ȭ
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, false);

        // �ִϸ��̼� ���� �ð�(2��) ���� ������
        yield return new WaitForSeconds(2.0f);

        // action�� ����� �Լ��� �ִٸ� ����
        if (action != null) action();

        // �ش� guai�� Raycast Ȱ��ȭ
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, true);
    }
    // �ش� �г��� MoveOut - �ִϸ��̼� ����
    IEnumerator OffAnimation(GAui gaui, Action action)
    {
        // �ش� gaui �ִϸ��̼� ����
        gaui.MoveOut(GSui.eGUIMove.SelfAndChildren);

        // �ش� gaui�� Raycast ��Ȱ��ȭ
        GSui.Instance.SetGraphicRaycasterEnable(gaui.gameObject, false);

        // �ִϸ��̼� ���� �ð�(2.5��) ���� ������
        yield return new WaitForSeconds(2.5f);

        // action�� ����� �Լ��� �ִٸ� ����
        if (action != null) action();

        // �ش� guai�� Raycast Ȱ��ȭ
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
