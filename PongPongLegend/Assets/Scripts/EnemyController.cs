using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Turret, Tank
}
public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyType type;
    [SerializeField] private float range;
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer circleRange;
    [SerializeField] private GunController gunObj;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private HUDController hUD;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        circleRange.gameObject.transform.localScale *= 2 * range;
        gunObj.range = range;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs((player.position - transform.position).magnitude);
        if (distance <= range)
        {
            circleRange.color = new Color(1, 0, 0, 0.02f); // Red color
            gunObj.auto = true;
        }
        else
        {
            circleRange.color = new Color(0, 1, 0, 0.02f); // Green color
            gunObj.auto = false;
        }
        if (type == EnemyType.Tank)
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        Debug.Log("Enemy take hit !!");
        if (health <= 0)
        {
            hUD.UpdateEnemy();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
