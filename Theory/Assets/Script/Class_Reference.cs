using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_Reference : MonoBehaviour
{
    class Animal
    {
        public string 종;

        public Animal(string 종)
        {
            this.종 = 종;
        }
    }
    void Start()
    {
        /*Animal animal1 = new Animal("코끼리");
        Animal animal2 = new Animal("사자");

        print("animal1 :" + animal1.종);
        print("animal2 :" + animal2.종);

        animal2 = animal1;
        print("animal1 :" + animal1.종);
        print("animal2 :" + animal2.종);

        animal1.종 = "호랑이";
        animal2.종 = "악어";
        print("animal1 :" + animal1.종);
        print("animal2 :" + animal2.종);

        int apple_count = 10;
        int banana_count = 5;

        print("사과 개수 :" + apple_count);
        print("바나나 개수 :" + banana_count);

        apple_count = banana_count;
        print("사과 개수 :" + apple_count);
        print("바나나 개수 :" + banana_count);

        apple_count = 100;
        banana_count = 50;
        print("사과 개수 :" + apple_count);
        print("바나나 개수 :" + banana_count);*/

        Animal animal1 = new Animal("코끼리");
        Animal animal2 = new Animal("사자");
        Animal animal3 = new Animal("토끼");

        // animal1(100) = animal2(200) => animal1(200) = animal2(200)
        animal1 = animal2;
        // animal2(200) = animal3(300) => animal2(300) = animal3(300)
        animal2 = animal3;
        // animal3(300) = animal1(200) => animal3(200) = animal1(200)
        animal3 = animal1;
        // ==> animal1(200) , animal2(300) , animal3(200)

        animal1.종 = "고라니";
        animal2.종 = "개";
        animal3.종 = "고양이";

        print("animal1 :" + animal1.종);
        print("animal2 :" + animal2.종);
        print("animal3 :" + animal3.종);
    }
}