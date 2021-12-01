# Planting-grass
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MtMethod : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(add(5, 6));
        Debug.Log(minus(5, 6));
        Debug.Log(mix(5, 6));
        Myname("한건희");
        Debug.Log(return2("Hello"));
        Debug.Log(TF(9));
        Debug.Log(nameTF("한건희"));
    }
    //1. 인자갑 2개 받는다 - 서로 더한값 리턴
    int add(int x, int y)
    {
        return x + y;
    }
    //2. 인자값 2개 받는다 - 서로 뺀값 리턴
    int minus(int x, int y)
    {
        return x - y;
    }
    //3. 인자값 2개 받는다 - 서로 곱한 값 리턴
    int mix(int x, int y)
    {
        return x * y;
    }
    //4. 본인의 이름을 출력
    void Myname(string name)
    {
        Debug.Log(name); 
    }
    //5. 인자값을 하나 받는다 - 넘겨받은 인자값을 더해서 출력
    // 예) 인자값 : "Hello" 리턴값 : "HelloHellow"
    string return2(string s)
    {
        return s += s;
    }
    //6. 인자값을 하나(숫자) 받는다 - 받은 값이 10보다 크면 true 아니면 false
    bool TF(int x)
    {
        if (x > 10)
            return true;
        else
            return false;
    }
    //7. 인자값을 하나(문자) 받는다 - 본인의 이름이면 true 아니면 false
    string My_name = "한건희";
    bool nameTF(string name)
    {
        if (name == My_name)
            return true;
        else
            return false;
    }
}
