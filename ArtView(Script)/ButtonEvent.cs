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

    // OVRinputModule_ArtView���� Click �̺�Ʈ�� �Ÿ��� �ٰ����� ��� ���� ȣ���� ��.
    // Button�� interactable�� �ӽ� ��Ȱ��Ȱ �Ͽ� ���� ȣ���� ����
    public IEnumerator inputModuleOnClickEvent()
    {
        GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(1.0f);

        GetComponent<Button>().interactable = true;
    }
}
