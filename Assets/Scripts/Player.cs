using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Weapons")]
    public List<Weapon> unlockedWeapons = new List<Weapon>();
    public Weapon currentWeapon;

    private bool canSwitchWeapons = false;

    void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
    }

    void Update()
    {
        HandleShooting();

        if (canSwitchWeapons)
            HandleWeaponSwitch();
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Shoot();
        }
    }

    void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && unlockedWeapons.Count > 0)
            EquipWeapon(0);

        if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedWeapons.Count > 1)
            EquipWeapon(1);

        if (Input.GetKeyDown(KeyCode.Alpha3) && unlockedWeapons.Count > 2)
            EquipWeapon(2);

        if (Input.GetKeyDown(KeyCode.Alpha4) && unlockedWeapons.Count > 3)
            EquipWeapon(3);
    }

    void EquipWeapon(int index)
    {
        if (currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);

        currentWeapon = unlockedWeapons[index];
        currentWeapon.gameObject.SetActive(true);
    }

    public void SetWeaponSwitchState(bool state)
    {
        canSwitchWeapons = state;
    }

    public void UnlockWeapon(WeaponType type)
    {
        foreach (Weapon w in unlockedWeapons)
        {
            if (w.data.weaponType == type)
                return;
        }

        Weapon[] allWeapons = GetComponentsInChildren<Weapon>(true);

        foreach (Weapon w in allWeapons)
        {
            if (w.data.weaponType == type)
            {
                unlockedWeapons.Add(w);
                w.gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    public void RestoreFullHealth()
    {
        currentHealth = maxHealth;
    }

    void Die()
    {
        Debug.Log("Game Over");
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }
}