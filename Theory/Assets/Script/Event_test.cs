using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Event.Onstart += Abc;
    }
    public void Abc(int value)
    {
        print(value + "���� �����߽��ϴ�.");
    }
}