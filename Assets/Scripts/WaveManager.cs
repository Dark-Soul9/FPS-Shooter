using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public int currentWave = 1;
    public int zombiesPerWave = 10;

    private int zombiesAlive;

    void Awake() => Instance = this;

    void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        Player.Instance.SetWeaponSwitchState(false);

        zombiesAlive = zombiesPerWave + (currentWave * 2);

        ZombieSpawner.Instance.SpawnWave(zombiesAlive);

        Debug.Log("Wave Started: " + currentWave);
    }

    public void ZombieKilled()
    {
        zombiesAlive--;

        if (zombiesAlive <= 0)
        {
            EndWave();
        }
    }

    void EndWave()
    {
        Player.Instance.SetWeaponSwitchState(true);

        //UpgradeUI.Instance.Open();
    }

    public void StartNextWave()
    {
        currentWave++;
        StartWave();
    }
}