using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_and_Dynamic : MonoBehaviour
{
    // 상수(constant)
    // 변하지 않는 값 (명령어 : const)
    // 프로젝트에서 변하지 않는 값에 이름을 붙여 사용.
    // 클래스 상단에 배치하여 변수와 구분하는게 좋음.
    // 상수 이름은 대문자로 표기
    const int BANANA_COUNT = 2;
    int apple_count;

    // 정적(static) <-> 동적(Dynamic)
    // * scope(스코프) : 구현부 안에서 선언한 것이 구현부 밖에서는  그 의미를 상실하는 것 => {}
    // * 값 형태 : 변수 자체에 메모리가 할당된 것
    // * 참조 형태 : 메모리를 할당받은 주소를 객체에 저장하는 것. 객체가 인스턴스를 참조한다.
    // 동적 = scope 정적 != scpoe
    // 변하지 않는다 <-> 변한다
    // scope에 영향을 받지 않는 변수
    // 객체와 무관하게 정적 할당받아 클래스 타입으로 접근하는 변수


    static int pineapple_count;
    // Start is called before the first frame update
    void Start()
    {
        //상수 활용 예시
        for (int i = 0; i < BANANA_COUNT; i++)
        {

        }

        //정적

        //동적의 의미
        int a = 1; //메모리를 할당받음, 동적, scope 
                   // 값 형태의 변수가 scope를 벗어난는 순간 메모리를 잃음

        Animal animal = new Animal(); // 메모리를 할당박음, 동적 할당
                                      // 참조형태의 객체는 scope를 벗어나는 순간
                                      // - 원칙상 메모리를 잃지는 않음
                                      // - 객체는 잃지만, 인스턴스가 사라지지는 않음.
                                      // - 인스턴스에 접근할 객체가 없어짐.
                                      // animal.name = "식물";       // 정적 멤버는 인스턴스 참조를 사용하여 접근할 수 없다.
        /*animal.Print();
        Animal.name = "식물";         // 정적 멤버는 클래스 타입으로 접근이 가능.
        Animal other = new Animal();
        other.Print();*/
    }

    class Animal
    {
        // 정적 멤버 변수
        // 클래스 구현부에서 정적 멤버를 초기화
        // 객체 1개를 만들때 정적 할당
        // 그 다음에는 객체를 만들어도 새로 정적할당하지 않음

        // name 필드의 의미 = Animal 타입의 모든 객체가 공유하는 정보
        public static string name = "동물";

        // 생명체의 코드 (동물, 식물 등)
        // Animal 클래스 타입이 가지는 lifeCode 정보
        public static int lifeCode = 1;

        // 일반 메서드
        // 일반 메서드는 모든 멤버에 접근가능.
        public void Print()
        {
            print(name);
        }

        // 정적 메서드
        // 정적 메서드는 정적 멤버에만 접근 가능.
        public static void PrintLifeCode()
        {
            print(lifeCode);
            //종 = "코끼리";
        }
    }
}