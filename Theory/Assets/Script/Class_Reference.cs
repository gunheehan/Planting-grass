using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Reference : MonoBehaviour
{
    class Animal
    {
        public string ��;

        public Animal(string ��)
        {
            this.�� = ��;
        }
    }
    void Start()
    {
        /*Animal animal1 = new Animal("�ڳ���");
        Animal animal2 = new Animal("����");

        print("animal1 :" + animal1.��);
        print("animal2 :" + animal2.��);

        animal2 = animal1;
        print("animal1 :" + animal1.��);
        print("animal2 :" + animal2.��);

        animal1.�� = "ȣ����";
        animal2.�� = "�Ǿ�";
        print("animal1 :" + animal1.��);
        print("animal2 :" + animal2.��);

        int apple_count = 10;
        int banana_count = 5;

        print("��� ���� :" + apple_count);
        print("�ٳ��� ���� :" + banana_count);

        apple_count = banana_count;
        print("��� ���� :" + apple_count);
        print("�ٳ��� ���� :" + banana_count);

        apple_count = 100;
        banana_count = 50;
        print("��� ���� :" + apple_count);
        print("�ٳ��� ���� :" + banana_count);*/

        Animal animal1 = new Animal("�ڳ���");
        Animal animal2 = new Animal("����");
        Animal animal3 = new Animal("�䳢");

        // animal1(100) = animal2(200) => animal1(200) = animal2(200)
        animal1 = animal2;
        // animal2(200) = animal3(300) => animal2(300) = animal3(300)
        animal2 = animal3;
        // animal3(300) = animal1(200) => animal3(200) = animal1(200)
        animal3 = animal1;
        // ==> animal1(200) , animal2(300) , animal3(200)

        animal1.�� = "����";
        animal2.�� = "��";
        animal3.�� = "�����";

        print("animal1 :" + animal1.��);
        print("animal2 :" + animal2.��);
        print("animal3 :" + animal3.��);
    }
}