using System;
using UnityEngine;

// 생명체로서 동작할 게임 오브젝트들을 위한 뼈대를 제공
// 체력, 데미지 받아들이기, 사망 기능, 사망 이벤트를 제공
public class LivingEntity : MonoBehaviour, IDamageable {
    public float startingHealth = 100f; // 시작 체력
    public float health { get; protected set; } // 현재 체력
    public bool dead { get; protected set; } // 사망 상태
    // 이벤트 : delegate 함수를 저장하는 변수
    // onDeath(); <- 호출
    // onDeath = onDamage; <- 저장하는 방식 중 하나
    // 이벤트를 호출하면 저장한 함수들이 실행 
    /*
     * LivingEntity에서는 onDeath에 저장하는 코드가 없다.
     * LivingEntity에서 어떤 걸 호출해야 할지 알수 없지만, 외부에서 구현한 기능을 호출하는 방식일때 이벤트를 쓴다.
     * 클래스 외부에서 onDeath에 저장해줌.
     * 이벤트를 사용하면 강하게 결합(커플링)된 코드를 해소할 수 있다.
     */
    public event Action onDeath; // 사망시 발동할 이벤트

    // 생명체가 활성화될때 상태를 리셋
    protected virtual void OnEnable() {
        // 사망하지 않은 상태로 시작
        dead = false;
        // 체력을 시작 체력으로 초기화
        health = startingHealth;
    }

    // 데미지를 입는 기능
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal) {
        // 데미지만큼 체력 감소
        health -= damage;

        // 체력이 0 이하 && 아직 죽지 않았다면 사망 처리 실행
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    // 체력을 회복하는 기능
    public virtual void RestoreHealth(float newHealth) {
        if (dead)
        {
            // 이미 사망한 경우 체력을 회복할 수 없음
            return;
        }

        // 체력 추가
        health += newHealth;
    }

    // 사망 처리
    public virtual void Die() {
        // onDeath 이벤트에 등록된 메서드가 있다면 실행
        if (onDeath != null)
        {
            onDeath();
        }

        // 사망 상태를 참으로 변경
        dead = true;
    }
}