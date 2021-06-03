using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // public attribute
    public bool useMouse;
    public GameObject bulletPrefab;
    public List<Transform> shootPoints;
    public Camera mainCamera;
    public ParticleSystem shootParticle;
    public float delay;
    public float delayOfEachBullet;
    public bool isPlayer;
    public GameObject effectPrefab;
    public Transform followPlayer;
    [System.NonSerialized] public bool auto = false;
    [System.NonSerialized] public float range;

    // private attribute
    private Vector2 followPoint;
    private Vector2 lookVector;
    private Animator gunAn;
    private bool isCountDownShoot = false;
    void Start()
    {
        range = -1;
        gunAn = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayer)
        {
            followPoint = Input.mousePosition;
            lookVector = mainCamera.ScreenToWorldPoint(followPoint) - transform.position;
            if (useMouse && (Input.GetMouseButtonDown(0) || auto))
            {
                if (!isCountDownShoot)
                {
                    isCountDownShoot = true;
                    gunAn.SetTrigger("Shoot");
                    StartCoroutine(CountDownShoot());
                }
            }
            if (useMouse && Input.GetMouseButtonDown(1))
            {
                auto = !auto;
            }
        }
        else if (auto)// for enemy
        {
            followPoint = followPlayer.transform.position;
            lookVector = (Vector3)followPoint - transform.position;
            if (!isCountDownShoot)
            {
                isCountDownShoot = true;
                gunAn.SetTrigger("Shoot");
                StartCoroutine(CountDownShoot());
            }
        }
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator CountDownShoot()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            if (range != -1)
                bullet.GetComponent<BulletController>().range = range;
            bullet.tag = gameObject.tag;
            yield return new WaitForSeconds(delayOfEachBullet);
        }
        yield return new WaitForSeconds(delay);
        isCountDownShoot = false;
    }

    public void Skill()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.tag = gameObject.tag;

            GameObject effect = Instantiate(effectPrefab, shootPoint.position, shootPoint.rotation);
            effect.transform.parent = transform;
        }
        Debug.Log("Boom!!!");
    }
}
