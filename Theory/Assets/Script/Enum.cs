using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    // enum(열거형)
    // enum 타입을 정의 함으로써 구성 요소를 알 수 있다.
    // enum 타입 안의 값은 정수로 되어 있음.
    // 적지 않으면, 0부터 시작하여 순차적으로 값이 올라감.

    // 과일 enum 타입 정의
    // 과일 코드를 기재해야 한다! "사과 = 0"
    enum FruitType
    {
        사과,
        바나나,
        파인애플
    }
    FruitType 우리과일; // FruitType 타잎의 우리과일

    // 거래처 1. 농협
    // 농협에 납품하는 여러 가지의 품목
    FruitType[] 농협거래품목;

    // 거래처 2. 이마트 트레이더스
    // 이마트에 납품하는 여러 가지의 품목
    FruitType[] 이마트거래품목;
    // Start is called before the first frame update
    void Start()
    {
        print("안녕하세요 우리과수원에 오신것을 환영합니다!");
        // enum 타입 변수도 값을 가질 수 있다.!
        우리과일 = FruitType.사과; // 우리과일 변수는 '사과' 값을 가짐.

        // 항목을 저장할 때 지정된 타입으로 넣을 수 있어 작업이 간편.
        // 가독성이 좋다.
        농협거래품목 = new FruitType[2];
        농협거래품목[0] = FruitType.사과;
        농협거래품목[1] = FruitType.바나나;

        이마트거래품목 = new FruitType[2];
        이마트거래품목[0] = FruitType.사과;
        이마트거래품목[1] = FruitType.파인애플;
    }
}