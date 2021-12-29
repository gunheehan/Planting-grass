using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �־��� Gun ������Ʈ�� ��ų� ������
public class PlayerShooter : MonoBehaviour
{
    public FPS_Gun gun; // ����� ��
    public Transform gunPivot; // �� ��ġ�� ������

    private PlayerManger playerManger; // �÷��̾��� �Է�
    private Animator playerAnimator; // �ִϸ����� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        //  �翵�� ������Ʈ���� ��������
        playerManger = GetComponent<PlayerManger>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
        gun.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
        gun.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �Է��� �����ϰ� �� �߻��ϰų� ������
        if(playerManger.fire)
        {
            // �߻� �Է� ���� �� �� �߻�
            gun.Fire();
        }
        else if(playerManger.reload)
        {
            // ������ �Է� ������ ������
            if(gun.Reload())
            {
                playerAnimator.SetTrigger("Reload");
            }
        }
    }
}
