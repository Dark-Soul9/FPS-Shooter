using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private float range;
    private float speed = 40f;

    private Vector3 startPosition;

    public void Initialize(float dmg, float rng)
    {
        damage = dmg;
        range = rng;
        startPosition = transform.position;

        Destroy(gameObject, 5f); // safety destroy
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Zombie zombie = other.GetComponent<Zombie>();
        if (zombie != null)
        {
            zombie.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}