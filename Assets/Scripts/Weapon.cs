using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;

    private float currentAmmoPercent = 1f; // 100%
    private int currentTier = 1;
    private float nextFireTime;

    public float CurrentMagazineSize =>
        data.magazineSize * (1 + data.magSizeIncreasePerTier * (currentTier - 1));

    public float CurrentReloadTime =>
        data.reloadTime * (1 - data.reloadReductionPerTier * (currentTier - 1));

    public void Shoot()
    {
        if (Time.time < nextFireTime) return;
        if (currentAmmoPercent <= 0f) return;

        nextFireTime = Time.time + (1f / data.fireRate);

        currentAmmoPercent -= 1f / CurrentMagazineSize;

        // Bullet instantiation here
        BulletSpawner.Instance.SpawnBullet(data.damage, data.range);

        MultiplierManager.Instance.RegisterShot(true);
    }

    public void MissedShot()
    {
        MultiplierManager.Instance.RegisterShot(false);
    }

    public void AddAmmoPercent(float percent)
    {
        currentAmmoPercent = Mathf.Clamp01(currentAmmoPercent + percent);
    }

    public void Upgrade()
    {
        if (currentTier < data.maxTier)
            currentTier++;
    }

    public float GetAmmoPercent() => currentAmmoPercent;
    public int GetTier() => currentTier;
}