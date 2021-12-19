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
        // 나누기 오류 감지
        catch(DivideByZeroException ie)
        {
            print(ie);
            b = 1;
            c = a / b;
        }
        // 비어있는 오류 감지
        catch(NullReferenceException ie) { }
        finally
        {
            print(c);
        }
        // 의도적으로 오류 발생
        throw new Exception("의도적인 오류");
    }
}
