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
        // ���콺 ������ ����
        mouseX += Input.GetAxis("Mouse X") * 10;
        // �÷��̾� ȸ���� ����
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    void playerMove()
    {
        // a, dŰ ������ ���� ����Ű�� �������� �� ��ȯ
        float moveX = Input.GetAxis("Horizontal");
        // w, sŰ �� �Ʒ� ����Ű�� �������� �� ��ȯ
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);

        character.Move(transform.TransformDirection(move) * Time.deltaTime * 10);
        // ĳ���� ��Ʈ�ѷ� �̵�(x,y,z)
        // transform.TransformDirection : ������ǥ -> ������ǥ �������� �ٲ۴�.
    }
}
