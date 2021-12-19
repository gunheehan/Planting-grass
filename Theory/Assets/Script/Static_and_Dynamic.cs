using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_and_Dynamic : MonoBehaviour
{
    // ���(constant)
    // ������ �ʴ� �� (��ɾ� : const)
    // ������Ʈ���� ������ �ʴ� ���� �̸��� �ٿ� ���.
    // Ŭ���� ��ܿ� ��ġ�Ͽ� ������ �����ϴ°� ����.
    // ��� �̸��� �빮�ڷ� ǥ��
    const int BANANA_COUNT = 2;
    int apple_count;

    // ����(static) <-> ����(Dynamic)
    // * scope(������) : ������ �ȿ��� ������ ���� ������ �ۿ�����  �� �ǹ̸� ����ϴ� �� => {}
    // * �� ���� : ���� ��ü�� �޸𸮰� �Ҵ�� ��
    // * ���� ���� : �޸𸮸� �Ҵ���� �ּҸ� ��ü�� �����ϴ� ��. ��ü�� �ν��Ͻ��� �����Ѵ�.
    // ���� = scope ���� != scpoe
    // ������ �ʴ´� <-> ���Ѵ�
    // scope�� ������ ���� �ʴ� ����
    // ��ü�� �����ϰ� ���� �Ҵ�޾� Ŭ���� Ÿ������ �����ϴ� ����


    static int pineapple_count;
    // Start is called before the first frame update
    void Start()
    {
        //��� Ȱ�� ����
        for (int i = 0; i < BANANA_COUNT; i++)
        {

        }

        //����

        //������ �ǹ�
        int a = 1; //�޸𸮸� �Ҵ����, ����, scope 
                   // �� ������ ������ scope�� ����� ���� �޸𸮸� ����

        Animal animal = new Animal(); // �޸𸮸� �Ҵ����, ���� �Ҵ�
                                      // ���������� ��ü�� scope�� ����� ����
                                      // - ��Ģ�� �޸𸮸� ������ ����
                                      // - ��ü�� ������, �ν��Ͻ��� ��������� ����.
                                      // - �ν��Ͻ��� ������ ��ü�� ������.
                                      // animal.name = "�Ĺ�";       // ���� ����� �ν��Ͻ� ������ ����Ͽ� ������ �� ����.
        /*animal.Print();
        Animal.name = "�Ĺ�";         // ���� ����� Ŭ���� Ÿ������ ������ ����.
        Animal other = new Animal();
        other.Print();*/
    }

    class Animal
    {
        // ���� ��� ����
        // Ŭ���� �����ο��� ���� ����� �ʱ�ȭ
        // ��ü 1���� ���鶧 ���� �Ҵ�
        // �� �������� ��ü�� ���� ���� �����Ҵ����� ����

        // name �ʵ��� �ǹ� = Animal Ÿ���� ��� ��ü�� �����ϴ� ����
        public static string name = "����";

        // ����ü�� �ڵ� (����, �Ĺ� ��)
        // Animal Ŭ���� Ÿ���� ������ lifeCode ����
        public static int lifeCode = 1;

        // �Ϲ� �޼���
        // �Ϲ� �޼���� ��� ����� ���ٰ���.
        public void Print()
        {
            print(name);
        }

        // ���� �޼���
        // ���� �޼���� ���� ������� ���� ����.
        public static void PrintLifeCode()
        {
            print(lifeCode);
            //�� = "�ڳ���";
        }
    }
}