//��� + Override 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheratance_test : Inheritance
{
    string schoolName;
    // Start is called before the first frame update
    void Start()
    {
        schoolName = "�� �ʵ��б�";
        gunName = "�Ѱ���";
        gunage = 26;

        info();
    }

    protected override void info()
    {
        base.info();
        print("���� �л��Դϴ�.");
    }

    protected override void Name()
    {
        print(gunName);
    }
}