using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    Rocket, TripleGun, DoubleGun, SingleGun
}
public class GunController : MonoBehaviour
{
    // public attribute
    public bool useMouse;
    public GunType gunType;
    public GameObject bulletPrefab;
    public List<Transform> shootPoints;
    public Camera mainCamera;
    public ParticleSystem shootParticle;
    public float delay;
    public GameObject effectPrefab;

    // private attribute
    private Vector2 followPoint;
    private Vector2 lookVector;
    private Animator gunAn;
    private bool isCountDownShoot = false;
    void Start()
    {
        gunAn = GetComponent<Animator>();
    }

    void Update()
    {
        followPoint = Input.mousePosition;
        if (useMouse && Input.GetMouseButton(0))
        {
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
        lookVector = mainCamera.ScreenToWorldPoint(followPoint) - transform.position;
        float angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator CountDownShoot()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.tag = gameObject.tag;
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
