using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float crouchSpeed;
    private float applySpeed;

    [SerializeField]
    private float jumpForce;

    // ���� ����
    private bool isRun = false;
    private bool isCruoch = false;
    private bool isGround = true;

    // �ɾ��� �� �󸶳� ������ �����ϴ� ����.
    [SerializeField]
    private float crouchPosY;
    private float originPosY;
    private float applyCrouchPosY;

    // ���� ����
    private CapsuleCollider capsuleCollider;

    // ī�޶� �ΰ���
    [SerializeField]
    private float lookSensitivity;

    // ī�޶� �Ѱ�
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;

    [SerializeField]
    private Camera Camera;
    private Rigidbody myRigid;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        originPosY = Camera.transform.localPosition.y;
        applyCrouchPosY = originPosY;
    }

    // Update is called once per frame
    void Update()
    {
        IsGround();
        TryJump();
        TryRun();
        TryCrouch();
        Move();
        CameraRotation();
        CharacterRotation();
    }
    //�ɱ� �õ�
    private void TryCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
    }
    // �ɱ� ����
    private void Crouch()
    {
        isCruoch = !isCruoch;
        
        if(isCruoch)
        {
            applySpeed = crouchSpeed;
            applyCrouchPosY = crouchPosY;
        }
        else
        {
            applySpeed = walkSpeed;
            applyCrouchPosY = originPosY;
        }
        StartCoroutine(CrouchCoroutine());
    }
    // �ε巯�� ���� ����(�ɱ�)
    IEnumerator CrouchCoroutine()
    {
        float _posY = Camera.transform.localPosition.y;
        int count = 0;

        while(_posY!=applyCrouchPosY)
        {
            count++;
            _posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.3f);
            Camera.transform.localPosition = new Vector3(0, _posY, 0);
            if (count > 15)
                break;
            yield return null;
        }
        Camera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0f);
    }

    // Ű���� ���� Player ����
    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }
    // �޸��� �õ�
    private void TryRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        { 
            RunningCancel();
        }
    }
    // �޸��� ����
    private void Running()
    {
        // ���� ���¿��� �޸��� ���� ���� ����.
        if (isCruoch)
            Crouch();
        isRun = true;
        applySpeed = runSpeed;
    }
    // �޸��� ���
    private void RunningCancel()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }
    // ���� �õ�
    private void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!isGround)
        {
            Jump();
        }
    }
    // ����
    private void Jump()
    {
        // ���� ���¿��� ������ ���� ���� ����.
        if (isCruoch)
            Crouch();

        myRigid.velocity = transform.up * jumpForce;
    }
    // ���� �浹 üũ
    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }
    // ���콺 ī�޶� ���� ����
    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -_cameraRotationX, cameraRotationLimit);

        Camera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    // ĳ���� �¿�ȸ��
    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }
}