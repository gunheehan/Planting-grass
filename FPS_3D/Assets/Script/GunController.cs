using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun;

    private float currentFireRate;

    private bool isReload = false;

    // Update is called once per frame
    void Update()
    {
        GunFireRateCalc();
        TryFire();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;
    }

    private void TryFire()
    {
        if(Input.GetButton("Fire1")&&currentFireRate<=0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if(!isReload)
        {
            if (currentGun.currentBulletCount > 0)
                Shoot();
            else
                ReloadCoroutine();
        }    
    }

    private void Shoot()
    {
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate; // 연사 속도 계산
        currentGun.muzzleFlash.Play();
        Debug.Log("총알 발사");
    }

    IEnumerator ReloadCoroutine()
    {
        isReload = true;

        currentGun.anim.SetTrigger("Reload");

        yield return new WaitForSeconds(currentGun.reloadTime);

        if(currentGun.carryBulletCount>0)
        {
            if(currentGun.carryBulletCount>=currentGun.reloadBulletCount)
            {
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
            }
            else
            {
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }
        }

        isReload = false;
    }    
}
