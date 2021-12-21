using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Gun : MonoBehaviour
{
    // ���� ���¸� ǥ���ϴµ� ����� Ÿ���� ����
    public enum State
    {
        Ready, // �߻� �غ��
        Empty, // źâ�� ��
        Reloading // ������ ��
    }

    public State state
    {
        get;
        private set;
    }

    public Transform fireTransform; // �Ѿ��� �߻�� ��ġ

    public ParticleSystem muzzleFlashEffect; // �ѱ� ȭ�� ȿ��
    public ParticleSystem shellEjectEffect; // ź�� ���� ȿ��

    private LineRenderer bulletLineRenderer; // �Ѿ� ������ �׸��� ���� ������

    private AudioSource gunAudioPlayer; // �� �Ҹ� �����
    public AudioClip shotClip; // �߻� �Ҹ�
    public AudioClip reloadClip; // ������ �Ҹ�

    public float damage = 25; // ���ݷ�
    private float fireDistance = 50; // �����Ÿ�

    public int amooRemain = 100; // ���� ź��
    public int magCapacity = 30; // źâ �뷮
    public int magAmmo; // ���� źâ�� �����ִ� ź��

    public float timeBetFire = 0.12f; // �Ѿ� �߻� ����
    public float reloadTime = 1.8f; // ������ �ҿ� �ð�
    private float lastFireTime; // ���� ���������� �߻��� ����

    private void Awake()
    {
        // ����� ������Ʈ���� ������ ��������
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // ����� ���� �ΰ��� ����
        bulletLineRenderer.positionCount = 2;
        // ���� �������� ��Ȱ��ȭ
        bulletLineRenderer.enabled = false;
    }

    // �� ���� �ʱ�ȭ
    private void OnEnable()
    {
        // ���� źâ�� ���� ä���
        magAmmo = magCapacity;

        // ���� ���� ���¸� ���� �� �غ� �� ���·� ����
        state = State.Ready;

        // ���������� ���� �� ������ �ʱ�ȭ
        lastFireTime = 0;
    }

    // �߻� �õ�
    public void Fire()
    {
        // ���� ���°� �߻� ������ �������� Ȯ��
        // ������ �� �߻� �������� timeBetFire �̻��� �ð��� �������� Ȯ��
        if(state==State.Ready&&Time.time>=lastFireTime+timeBetFire)
        {
            // ������ �� �߻� ���� ����
            lastFireTime = Time.time;
            // ���� �߻� ó�� ����
            Shot();
        }
    }

    // ���� �߻� ó��
    private void Shot()
    {
        // ����ĳ��Ʈ�� ���� �浹 ������ �����ϴ� �����̳�
        RaycastHit hit;

        // ź���� ���� ��ġ�� ������ ����
        Vector3 hitposition = Vector3.zero;

        // ����ĳ��Ʈ(���� ����, ����, �浹 ���� �����̳�, �����Ÿ�)
        // if true�� �浹 �Ǿ���!
        if(Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
            // ���� ���, ������ �������� ���� �� �ִ� target�� ã������.
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            // �������κ��� IDamageable ������Ʈ�� �������µ� �����ߴٸ�
            if(target != null)
            {
                // ������ OnDamage �Լ��� ������� ���濡�� ������ �߰�
                target.OnDamage(damage, hit.point, hit.normal);
            }
            // ���̰� �浹�� ��ġ ����
            hitposition = hit.point;
        }
        else
        {
            // ���̰� �ٸ� ��ü�� �浹���� �ʾҴٸ�
            // ź���� �ִ� �����Ÿ����� ���ư��� ���� ��ġ�� �浹 ��ġ�� ����
            hitposition = fireTransform.position + fireTransform.forward * fireDistance;
        }

        // �߻� ����Ʈ ����
        StartCoroutine(ShotEffect(hitposition));
        // ���� ź�� ���� -1
        magAmmo--;
        if(magAmmo<=0)
        {
            // źâ�� ���� ź���� ���ٸ� ���� ���� ���¸� Empty�� ����
            state = State.Empty;
        }
    }

    // �߻� ����Ʈ�� �Ҹ��� ����ϰ� �Ѿ� ������ �׸���
    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        // �ѱ� ȭ�� ȿ�� ���
        muzzleFlashEffect.Play();

        // ź�� ���� ȿ�� ���
        shellEjectEffect.Play();

        // �Ѱ� �Ҹ� ���
        gunAudioPlayer.PlayOneShot(shotClip);

        // ���� �������� �ѱ��� ��ġ
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        // ���� ������ �Է����� ���� �浹 ��ġ
        bulletLineRenderer.SetPosition(1, hitPosition);
        // ���� �������� Ȱ��ȭ�Ͽ� �Ѿ� ������ �׸���
        bulletLineRenderer.enabled = true;

        // 0.03�� ���� ��� ó���� ���
        yield return new WaitForSeconds(0.03f);

        // ���� �������� ��Ȱ��ȭ�Ͽ� �Ѿ� ������ �����
        bulletLineRenderer.enabled = false;
    }

    // ������ �õ�
    public bool Reload()
    {
        if(state==State.Reloading||amooRemain<=0||magAmmo>=magCapacity)
        {
            // �̹� ������ ���̰ų� ���� ź���� ���ʰ� źâ�� ź���� ���� �� ���� ��� �������� �� ����.
            return false;
        }
        // ������ ó�� ����
        StartCoroutine(ReloadRoutine());
        return true;
    }

    // ���� ������ ó���� ����
    private IEnumerator ReloadRoutine()
    {
        // ���� ���¸� ������ �� ���·� ��ȯ
        state = State.Reloading;

        // ������ �Ҹ� ���
        gunAudioPlayer.PlayOneShot(reloadClip);

        // ������ �ҿ� �ð� ��ŭ ó���� ����
        yield return new WaitForSeconds(reloadTime);

        // źâ�� ä�� ź���� ���
        int ammoToFill = magCapacity = magAmmo;

        // źâ�� ä���� �� ź���� ���� ź�˺��� ���ٸ�
        // ä���� �� ź�� ���� ���� ź�� ���� ���� ����
        if(amooRemain<ammoToFill)
        {
            ammoToFill = amooRemain;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
