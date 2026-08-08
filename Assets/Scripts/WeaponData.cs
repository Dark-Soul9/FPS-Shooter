using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType;

    [Header("Base Stats")]
    public float damage;
    public float range;
    public float fireRate;

    [Header("Ammo")]
    public int magazineSize;
    public int maxBackupAmmo;
    public float reloadTime;

    [Header("Upgrade Scaling")]
    public int maxTier = 5;
    public float magSizeIncreasePerTier = 0.2f; // 20% increase
    public float reloadReductionPerTier = 0.1f;   // 10% increase
}