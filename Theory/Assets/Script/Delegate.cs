using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegate : MonoBehaviour
{
    public delegate void ChainFunction(int value);
    ChainFunction chain;

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
        chain += SetPower;
        chain += SetDefence;

        chain -= SetDefence;
        chain(5);
    }
}
