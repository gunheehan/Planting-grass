using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    // enum(������)
    // enum Ÿ���� ���� �����ν� ���� ��Ҹ� �� �� �ִ�.
    // enum Ÿ�� ���� ���� ������ �Ǿ� ����.
    // ���� ������, 0���� �����Ͽ� ���������� ���� �ö�.

    // ���� enum Ÿ�� ����
    // ���� �ڵ带 �����ؾ� �Ѵ�! "��� = 0"
    enum FruitType
    {
        ���,
        �ٳ���,
        ���ξ���
    }
    FruitType �츮����; // FruitType Ÿ���� �츮����

    // �ŷ�ó 1. ����
    // ������ ��ǰ�ϴ� ���� ������ ǰ��
    FruitType[] �����ŷ�ǰ��;

    // �ŷ�ó 2. �̸�Ʈ Ʈ���̴���
    // �̸�Ʈ�� ��ǰ�ϴ� ���� ������ ǰ��
    FruitType[] �̸�Ʈ�ŷ�ǰ��;
    // Start is called before the first frame update
    void Start()
    {
        print("�ȳ��ϼ��� �츮�������� ���Ű��� ȯ���մϴ�!");
        // enum Ÿ�� ������ ���� ���� �� �ִ�.!
        �츮���� = FruitType.���; // �츮���� ������ '���' ���� ����.

        // �׸��� ������ �� ������ Ÿ������ ���� �� �־� �۾��� ����.
        // �������� ����.
        �����ŷ�ǰ�� = new FruitType[2];
        �����ŷ�ǰ��[0] = FruitType.���;
        �����ŷ�ǰ��[1] = FruitType.�ٳ���;

        �̸�Ʈ�ŷ�ǰ�� = new FruitType[2];
        �̸�Ʈ�ŷ�ǰ��[0] = FruitType.���;
        �̸�Ʈ�ŷ�ǰ��[1] = FruitType.���ξ���;
    }
}