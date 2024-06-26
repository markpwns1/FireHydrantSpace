using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenLevel : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float oxygenDepletionRate = 0.2f;
    public float currentOxygen;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentOxygen = maxOxygen;
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentOxygen > 0)
        {
            currentOxygen -= oxygenDepletionRate * Time.deltaTime;
            if (currentOxygen <= 0) 
            {
                currentOxygen = 0;
                // OutOfOxygen();
            }
        }
    }

    public void RefillOxygen(float amount)
    {
        if (playerHealth != null)
        {
            currentOxygen += amount;
            if (currentOxygen > maxOxygen) currentOxygen = maxOxygen;
        }
    }

    // void OutOfOxygen()
    // {
    //     if (playerHealth != null)
    //     {
    //         playerHealth.Die(); // Player is dead :D
    //     }
    // }

    public void DepleteOxygen(float amount)
    {
        currentOxygen -= amount;
        if (currentOxygen < 0)
        {
            currentOxygen = 0;
            // OutOfOxygen();
        }
    }

    public float GetCurrentOxygen()
    {
        return currentOxygen;
    }
}
