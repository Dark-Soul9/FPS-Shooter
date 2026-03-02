using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public static BulletSpawner Instance;

    [Header("References")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnBullet(float damage, float range)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(damage, range);
    }
}