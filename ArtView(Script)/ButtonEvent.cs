using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Enter : Hover        Down : Click
public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public void OnPointerEnter(PointerEventData add)
    {
        AudioManager.instance.PlayHoverSound();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        AudioManager.instance.PlayClickSound();
    }

    // OVRinputModule_ArtView에서 Click 이벤트가 거리가 다가왔을 경우 무한 호출이 됨.
    // Button의 interactable을 임시 비활성활 하여 무한 호출을 방지
    public IEnumerator inputModuleOnClickEvent()
    {
        GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(1.0f);

        GetComponent<Button>().interactable = true;
    }
}
