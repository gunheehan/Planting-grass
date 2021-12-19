using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ �Ӽ�(Attribute)
// ����Ƽ�� ������ �۾� ȯ���� ������ �� �ִ�!
// ���ȣ []�� ����Ͽ� �Ӽ� ����� ������.

public class Attribute : MonoBehaviour
{
    [Header("ü��")]
    public Color healthColor = Color.red;
    public int hp;
    [HideInInspector]
    public int max_hp = 100;

    [Header("����")]
    public Color manaColor = Color.blue;
    public int mp;
    [HideInInspector]
    public int max_mp = 50;
}
