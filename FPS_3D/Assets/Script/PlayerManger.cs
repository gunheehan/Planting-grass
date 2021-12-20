using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    CharacterController character;

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
    }

    void playerMove()
    {
        // a, d키 오른쪽 왼쪽 방향키를 눌었을때 값 반환
        float moveX = Input.GetAxis("Horizontal");
        // w, s키 위 아래 방향키를 눌렀을때 값 반환
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);

        character.Move(transform.TransformDirection(move) * Time.deltaTime * 10);
        // 캐릭터 컨트롤로 이동(x,y,z)
        // transform.TransformDirection : 로컬좌표 -> 월드좌표 기준으로 바꾼다.
    }
}
