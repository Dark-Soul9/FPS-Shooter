using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    public float ammoPercent = 0.3f;

    void OnMouseDown()
    {
        Player.Instance.currentWeapon.AddBackupAmmoPercent(ammoPercent);
        Destroy(gameObject);
    }
}