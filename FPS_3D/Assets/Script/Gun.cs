using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string GunName; // ���� �̸�
    public float range; // ���� �Ÿ�
    public float accuracy; // ��Ȯ��
    public float fireRate; // ���� �ӵ�
    public float reloadTime; // ������ �ӵ�.

    public int damage; // ���� ������

    public int reloadBulletCount; // �Ѿ� ������ ����
    public int currentBulletCount; // ���� ź������ �����ִ� �Ѿ��� ����
    public int maxBulletCount; // �ִ� ���� ���� �Ѿ� ����
    public int carryBulletCount; // ���� �����ϰ� �ִ� �Ѿ� ����

    public float retroAcrionForce; // �ݵ� ����
    public float retroActionFineSightForce; // �����ؽ��� �ݵ� ����


    public Vector3 fineSightOriginPos;
    public Animator anim;
    public ParticleSystem muzzleFlash;

    public AudioClip fire_Sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
