using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주어진 Gun 오브젝트를 쏘거나 재장전
public class PlayerShooter : MonoBehaviour
{
    public FPS_Gun gun; // 사용할 총
    public Transform gunPivot; // 총 배치의 기준점

    private PlayerManger playerManger; // 플레이어의 입력
    private Animator playerAnimator; // 애니메이터 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        //  사영할 컴포넌트들을 가져오기
        playerManger = GetComponent<PlayerManger>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // 슈터가 비활성화될 때 총도 함께 비활성화
        gun.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // 슈터가 비활성화될 때 총도 함께 비활성화
        gun.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 입력을 감지하고 총 발사하거나 재장전
        if(playerManger.fire)
        {
            // 발사 입력 감지 시 총 발사
            gun.Fire();
        }
        else if(playerManger.reload)
        {
            // 재장전 입력 감지시 재장전
            if(gun.Reload())
            {
                playerAnimator.SetTrigger("Reload");
            }
        }
    }
}
