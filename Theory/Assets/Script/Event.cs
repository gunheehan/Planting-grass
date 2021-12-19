using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    public delegate void ChainFunction(int value);
    public static event ChainFunction Onstart;

    int power;
    int defence;

    public void SetPower(int value)
    {
        power += value;
        print("Power�� ����" + value + "��ŭ �����߽��ϴ�. �� power�� �� = " + power);
    }

    public void SetDefence(int value)
    {
        defence += value;
        print("defence�� ���� " + value + "��ŭ �����߽��ϴ�. �� defence�� �� = " + power);
    }
    // Start is called before the first frame update
    void Start()
    {
        Onstart += SetPower;
        Onstart += SetDefence;
    }

    private void OnDisable()
    {
        Onstart(5);
    }
}