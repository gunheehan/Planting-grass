//상속 _Override 부모클래스
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Inheritance : MonoBehaviour
{
    protected string gunName;
    protected int gunage;

    protected virtual void info()
    {
        print("나는 인간입니다.");
    }

    abstract protected void Name();
}