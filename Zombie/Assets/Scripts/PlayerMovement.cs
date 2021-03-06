using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도

    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    // 컴포넌트들이 초기화될 때 실행되는 함수 (첫 번째 프레임 전)
    // 컴포넌트를 참조할 때 사용
    private void Awake()
    {

        // 사용할 컴포넌트들의 참조를 가져오기

        // playerInput 객체는 PlayerMovement 인스턴스(컴포넌트)가 달려있는
        // 오브젝트 (= Player Character)의
        // PlayerInput 인스턴스(컴포넌트)를 참조한다.
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // 컴포넌트들이 초기화 되고 난 후에 실행되는 함수 (첫 번째 프레임 전)
    // 스크립트들끼리 연동시킬때 사용
    private void Start()
    {


    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    // transform (위치) Rigidbody (물리 엔진)
    private void FixedUpdate()
    {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행

        // 회전 실행
        Rotate();

        // 움직임 실행
        Move();

        // 입력값에 따라 애니메이터의 Move 파라미터값 변경
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    // 매 프레임마다 실행할 것
    private void Update()
    {

    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {

        // moveDistance : 상대적으로 이동할 거리 계산
        // playerInput.move : S키와 W키를 누름으로 -1 ~ 1 값을 가짐
        // transform.forward : 방향 벡터
        // ex) Vector3 v = new Vector(1, 0, 0); 벡터의 길이값이 1
        // moveSpeed : 이동 속도
        // Time.deltaTime : 현재 프레임 실행 시각 - 이전 프레임 실행 시각 = 실행 시간 간격
        Vector3 moveDistance = playerInput.move * transform.forward
                                * moveSpeed * Time.deltaTime;

        // 리지드바디를 이용해 게임 오브젝트 위치 변경
        // playerRigidbody.position = 현재 위치
        // playerRigidbody.position + moveDistance = 이동할 위치
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {

        // turn : 상대적으로 회전할 수치 계산
        // playerInput.rotate : A키와 D키를 누름으로 -1 ~ 1 값을 가짐
        // rotateSpeed : 회전 속도
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 회전 변경
        // Quaternion.Euler 함수를 사용해 y축으로 turn만큼 회전
        playerRigidbody.rotation = playerRigidbody.rotation
                                    * Quaternion.Euler(0, turn, 0f);
    }
}