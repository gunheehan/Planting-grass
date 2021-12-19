//상속 + Override 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheratance_test : Inheritance
{
    string schoolName;
    // Start is called before the first frame update
    void Start()
    {
        schoolName = "건 초등학교";
        gunName = "한건희";
        gunage = 26;

        info();
    }

    protected override void info()
    {
        base.info();
        print("나는 학생입니다.");
    }

    protected override void Name()
    {
        print(gunName);
    }
}