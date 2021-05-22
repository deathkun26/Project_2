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
    public GunType gunType;
    public GameObject bulletPrefab;
    public List<Transform> shootPoints;
    public Camera mainCamera;

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
        if (Input.GetMouseButton(0))
        {
            if (!isCountDownShoot)
                StartCoroutine(CountDownShoot());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SkillE();
        }
    }

    void FixedUpdate()
    {
        lookVector = mainCamera.ScreenToWorldPoint(followPoint) - transform.position;
        float angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void SkillE()
    {

    }

    IEnumerator CountDownShoot()
    {
        isCountDownShoot = true;
        foreach (Transform shootPoint in shootPoints)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
        yield return new WaitForSeconds(0.5f);
        isCountDownShoot = false;
    }

    IEnumerator CountDownSkillE()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
