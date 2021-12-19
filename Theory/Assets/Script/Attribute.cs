using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 속성(Attribute)
// 유니티는 나만의 작업 환경을 구축할 수 있다!
// 대괄호 []를 사용하여 속성 기능을 가져옴.

public class Attribute : MonoBehaviour
{
    [Header("체력")]
    public Color healthColor = Color.red;
    public int hp;
    [HideInInspector]
    public int max_hp = 100;

    [Header("마나")]
    public Color manaColor = Color.blue;
    public int mp;
    [HideInInspector]
    public int max_mp = 50;
}
