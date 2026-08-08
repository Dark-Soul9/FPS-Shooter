using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public WeaponData data;

    private int currentMagazineAmmo;
    private int currentBackupAmmo;

    private int currentTier = 1;
    private float nextFireTime;
    private bool isReloading = false;

    void Start()
    {
        currentMagazineAmmo = GetCurrentMagazineSize();
        currentBackupAmmo = data.maxBackupAmmo;
    }

    int GetCurrentMagazineSize()
    {
        return Mathf.RoundToInt(
            data.magazineSize *
            (1 + data.magSizeIncreasePerTier * (currentTier - 1))
        );
    }

    float GetCurrentReloadTime()
    {
        return data.reloadTime *
               (1 - data.reloadReductionPerTier * (currentTier - 1));
    }

    public void Shoot()
    {
        if (isReloading)
            return;

        if (Time.time < nextFireTime)
            return;

        if (currentMagazineAmmo <= 0)
        {
            Reload();
            return;
        }

        nextFireTime = Time.time + (1f / data.fireRate);

        currentMagazineAmmo--;

        BulletSpawner.Instance.SpawnBullet(data.damage, data.range);
    }

    public void Reload()
    {
        if (isReloading)
            return;

        if (currentBackupAmmo <= 0)
            return;

        if (currentMagazineAmmo >= GetCurrentMagazineSize())
            return;

        StartCoroutine(ReloadRoutine());
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;

        yield return new WaitForSeconds(GetCurrentReloadTime());

        int neededAmmo = GetCurrentMagazineSize() - currentMagazineAmmo;
        int ammoToLoad = Mathf.Min(neededAmmo, currentBackupAmmo);

        currentMagazineAmmo += ammoToLoad;
        currentBackupAmmo -= ammoToLoad;

        isReloading = false;
    }

    public void AddBackupAmmoPercent(float percent)
    {
        int amount = Mathf.RoundToInt(data.maxBackupAmmo * percent);
        currentBackupAmmo = Mathf.Clamp(
            currentBackupAmmo + amount,
            0,
            data.maxBackupAmmo
        );
    }

    public void RefillAllAmmo()
    {
        currentBackupAmmo = data.maxBackupAmmo;
        currentMagazineAmmo = GetCurrentMagazineSize();
    }

    public void Upgrade()
    {
        if (currentTier < data.maxTier)
        {
            currentTier++;
        }
    }

    public int GetCurrentMagazineAmmo() => currentMagazineAmmo;
    public int GetCurrentBackupAmmo() => currentBackupAmmo;
    public int GetTier() => currentTier;
    public bool IsReloading() => isReloading;
}