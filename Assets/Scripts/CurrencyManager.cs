using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    private int zombieKillCounter = 0;
    private int coins = 0;

    void Awake() => Instance = this;

    public void RegisterZombieKill()
    {
        zombieKillCounter++;

        if (zombieKillCounter >= 5)
        {
            zombieKillCounter = 0;

            int multiplier = MultiplierManager.Instance.GetMultiplier();
            coins += 1 * multiplier;
        }
    }

    public int GetCoins() => coins;
    public void SpendCoins(int amount) => coins -= amount;
}