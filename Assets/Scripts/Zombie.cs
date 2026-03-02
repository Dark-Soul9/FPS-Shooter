using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 50f;
    public float speed = 2f;
    public float attackDamage = 10f;
    public float attackRate = 1.2f;

    private float nextAttackTime;

    void Update()
    {
        MoveTowardPlayer();
    }

    void MoveTowardPlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            Player.Instance.transform.position,
            speed * Time.deltaTime
        );
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;
                Player.Instance.TakeDamage(attackDamage);
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        CurrencyManager.Instance.RegisterZombieKill();
        WaveManager.Instance.ZombieKilled();
        Destroy(gameObject);
    }
}