using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameSpace;

public class HelloClass08Coroutine : MonoBehaviour
{
    // 코루틴
    // 일반적인 프로그램은 순차적 프로그래밍 기법을 씀. 위 -> 아래
    // 흐름도가 한개라는게 문제. -> 일이 끝나기 전까지는 다른 일이 일어날 수 없음.
    // 병렬로 일처리를 해주어야 할 때.

    // 쓰레드(Thread)를 이해하면 깊게 이해할 수 있음.

    // 코루틴(Coroutine) Co - Routine
    // Co : 협력하다. Routine : 반복적인 양
    // 기존 일을 10초동안 하고 있음. -> 누군가가 이걸 켜주세요라고 요청.
    // -> 잠깐 나의 시간을 떼서 켜주는걸 도와줌 -> 켜지면 다시 기존일로 돌아감.

    // Start is called before the first frame update
    void Start()
    {
        print("코루틴 함수 예제");
        StartCoroutine(CleaningRoomA());
        StartCoroutine(CleaningRoomB());
        print("Start() 종료");
        // 외부 namespcaetest 네임스페이스에 접근하여 소속 클래스 타입으로 객체 선언
        // using NamespaceText 키워드를 통해 바로 클래스 선언 가능
        오로나민C c;


    }

    // Room A를 잠깐 청소해달라고 여청하는 코루틴 함수
    // 반드시 
    IEnumerator CleaningRoomA()
    {
        print("A방 청소를 시작합니다.");

        yield return new WaitForSeconds(5.0f);

        print("A방 청소를 마칩니다.");
    }

    // Room B를 잠깐 청소해달라고 여청하는 코루틴 함수
    IEnumerator CleaningRoomB()
    {
        print("B방 청소를 시작합니다.");

        yield return new WaitForSeconds(3.0f);

        print("B방 청소를 마칩니다.");
    }
}