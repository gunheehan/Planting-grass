using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Exception_ : MonoBehaviour
{
    int a = 5;
    int b = 0;
    int c;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            c = a / b;
        }
        // ������ ���� ����
        catch(DivideByZeroException ie)
        {
            print(ie);
            b = 1;
            c = a / b;
        }
        // ����ִ� ���� ����
        catch(NullReferenceException ie) { }
        finally
        {
            print(c);
        }
        // �ǵ������� ���� �߻�
        throw new Exception("�ǵ����� ����");
    }
}
