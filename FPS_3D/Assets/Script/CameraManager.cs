using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform follow;
    [SerializeField] float m_Speed;
    [SerializeField] float m_Zoom = 3f;
    [SerializeField] float m_MaxRayDist = 1;
    RaycastHit m_Hit;
    Vector2 m_Input;


    // 마우스 스피드
    float mouseSpeed = 10;
    float mouseY = 0;

    // Update is called once per frame
    /*void Update()
    {
        // 마우스 위 아래
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;

        // Mathf.Clamp(변수, 제한최소값, 최대값)
        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);

        // 로컬 회전값 조정
        // mouseY += 를 할때 무조건 값이 +가 나오기 때문에-mouseY로 넣어줘야 위아래가 정상적으로 작동
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }*/

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            m_Input.x = Input.GetAxis("Mouse X");
            m_Input.y = Input.GetAxis("Mouse Y");

            if (m_Input.magnitude != 0)
            {
                Quaternion q = follow.rotation;
                q.eulerAngles = new Vector3(q.eulerAngles.x + m_Input.y * m_Speed, q.eulerAngles.y + m_Input.x * m_Speed, q.eulerAngles.z);
                follow.rotation = q;

            }
        }
    }


    public void LateUpdate()
    {
        Rotate();
        Zoom();
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll!=0)
        {
            Transform cam = Camera.main.transform;
            if(CheckRay(cam, scroll))
            {
                Vector3 targetDist = cam.transform.position - follow.transform.position;
                targetDist = Vector3.Normalize(targetDist);
                Camera.main.transform.position -= (targetDist * scroll * m_Zoom);
            }
        }
        Camera.main.transform.LookAt(follow.transform);
    }

    bool CheckRay(Transform cam, float scroll)
    {
        if(Physics.Raycast(cam.position, transform.forward, out  m_Hit, m_MaxRayDist))
        {
            cam.position += new Vector3(0, 0, m_Hit.point.z);
            return false;
        }
        return true;
    }
}
