using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    CharacterController character;

    public string moveAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string rotateAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름

    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값

    float mouseX = 0;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        // 마우스 오른쪽 왼쪽
        mouseX += Input.GetAxis("Mouse X") * 10;
        // 플레이어 회전값 조정
        transform.eulerAngles = new Vector3(0, mouseX, 0);

        //fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);
        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);
    }

    void playerMove()
    {
        // a, d키 오른쪽 왼쪽 방향키를 눌었을때 값 반환
        float moveX = Input.GetAxis(rotateAxisName);
        // w, s키 위 아래 방향키를 눌렀을때 값 반환
        float moveZ = Input.GetAxis(moveAxisName);

        Vector3 move = new Vector3(moveX, 0, moveZ);

        character.Move(transform.TransformDirection(move) * Time.deltaTime * 10);
        // 캐릭터 컨트롤로 이동(x,y,z)
        // transform.TransformDirection : 로컬좌표 -> 월드좌표 기준으로 바꾼다.
    }
}
