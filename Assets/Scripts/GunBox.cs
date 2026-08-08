using UnityEngine;

public class GunBox : MonoBehaviour
{
    public WeaponType unlockWeapon;

    void OnMouseDown()
    {
        Player.Instance.UnlockWeapon(unlockWeapon);
        Destroy(gameObject);
    }
}