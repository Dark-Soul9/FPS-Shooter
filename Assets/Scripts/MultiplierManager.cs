using UnityEngine;

public class MultiplierManager : MonoBehaviour
{
    public static MultiplierManager Instance;

    private int hitCounter = 0;
    private int multiplier = 1;
    private int maxMultiplier = 7;

    void Awake() => Instance = this;

    public void RegisterShot(bool hit)
    {
        if (!hit)
        {
            ResetMultiplier();
            return;
        }

        hitCounter++;

        if (hitCounter % 7 == 0 && multiplier < maxMultiplier)
        {
            multiplier++;
        }
    }

    void ResetMultiplier()
    {
        multiplier = 1;
        hitCounter = 0;
    }

    public int GetMultiplier() => multiplier;
}