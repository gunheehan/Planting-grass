//��� _Override �θ�Ŭ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Inheritance : MonoBehaviour
{
    protected string gunName;
    protected int gunage;

    protected virtual void info()
    {
        print("���� �ΰ��Դϴ�.");
    }

    abstract protected void Name();
}