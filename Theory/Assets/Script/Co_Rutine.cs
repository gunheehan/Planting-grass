using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameSpace;

public class HelloClass08Coroutine : MonoBehaviour
{
    // �ڷ�ƾ
    // �Ϲ����� ���α׷��� ������ ���α׷��� ����� ��. �� -> �Ʒ�
    // �帧���� �Ѱ���°� ����. -> ���� ������ �������� �ٸ� ���� �Ͼ �� ����.
    // ���ķ� ��ó���� ���־�� �� ��.

    // ������(Thread)�� �����ϸ� ��� ������ �� ����.

    // �ڷ�ƾ(Coroutine) Co - Routine
    // Co : �����ϴ�. Routine : �ݺ����� ��
    // ���� ���� 10�ʵ��� �ϰ� ����. -> �������� �̰� ���ּ����� ��û.
    // -> ��� ���� �ð��� ���� ���ִ°� ������ -> ������ �ٽ� �����Ϸ� ���ư�.

    // Start is called before the first frame update
    void Start()
    {
        print("�ڷ�ƾ �Լ� ����");
        StartCoroutine(CleaningRoomA());
        StartCoroutine(CleaningRoomB());
        print("Start() ����");
        // �ܺ� namespcaetest ���ӽ����̽��� �����Ͽ� �Ҽ� Ŭ���� Ÿ������ ��ü ����
        // using NamespaceText Ű���带 ���� �ٷ� Ŭ���� ���� ����
        ���γ���C c;


    }

    // Room A�� ��� û���ش޶�� ��û�ϴ� �ڷ�ƾ �Լ�
    // �ݵ�� 
    IEnumerator CleaningRoomA()
    {
        print("A�� û�Ҹ� �����մϴ�.");

        yield return new WaitForSeconds(5.0f);

        print("A�� û�Ҹ� ��Ĩ�ϴ�.");
    }

    // Room B�� ��� û���ش޶�� ��û�ϴ� �ڷ�ƾ �Լ�
    IEnumerator CleaningRoomB()
    {
        print("B�� û�Ҹ� �����մϴ�.");

        yield return new WaitForSeconds(3.0f);

        print("B�� û�Ҹ� ��Ĩ�ϴ�.");
    }
}