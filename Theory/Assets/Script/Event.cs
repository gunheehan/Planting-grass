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
        print("Power의 값이" + value + "만큼 증가했습니다. 총 power의 값 = " + power);
    }

    public void SetDefence(int value)
    {
        defence += value;
        print("defence의 값이 " + value + "만큼 증가했습니다. 총 defence의 값 = " + power);
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