using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    CharacterController character;

    public string moveAxisName = "Vertical"; // �յ� �������� ���� �Է��� �̸�
    public string rotateAxisName = "Horizontal"; // �¿� ȸ���� ���� �Է��� �̸�
    public string fireButtonName = "Fire1"; // �߻縦 ���� �Է� ��ư �̸�
    public string reloadButtonName = "Reload"; // �������� ���� �Է� ��ư �̸�

    public bool fire { get; private set; } // ������ �߻� �Է°�
    public bool reload { get; private set; } // ������ ������ �Է°�

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

        //fire�� ���� �Է� ����
        fire = Input.GetButton(fireButtonName);
        // reload�� ���� �Է� ����
        reload = Input.GetButtonDown(reloadButtonName);
    }

    void playerMove()
    {
        // a, dŰ ������ ���� ����Ű�� �������� �� ��ȯ
        float moveX = Input.GetAxis(rotateAxisName);
        // w, sŰ �� �Ʒ� ����Ű�� �������� �� ��ȯ
        float moveZ = Input.GetAxis(moveAxisName);

        Vector3 move = new Vector3(moveX, 0, moveZ);

        character.Move(transform.TransformDirection(move) * Time.deltaTime * 10);
        // ĳ���� ��Ʈ�ѷ� �̵�(x,y,z)
        // transform.TransformDirection : ������ǥ -> ������ǥ �������� �ٲ۴�.
    }
}
