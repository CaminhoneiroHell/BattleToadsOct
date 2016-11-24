using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 10;
    [SerializeField]
    int curHealth;
    [SerializeField]
    int regenarateAmount = 1;
    [SerializeField]
    float regenarationRate = 2f;

    void Start()
    {
        curHealth = maxHealth;

        InvokeRepeating("Regenerate", regenarationRate, regenarationRate);
    }

    void Regenerate()
    {
        Debug.Log("Regenerando Life");
        if (curHealth < maxHealth)
            curHealth += regenarateAmount;

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        EventManager.TakeDamage(curHealth / (float)maxHealth);
    }

    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;

        if (curHealth < 0)
            curHealth = 0;

        EventManager.TakeDamage(curHealth / (float)maxHealth);
        if (curHealth < 1)
        {
            GetComponent<Explosion>().BlowUp();
            //Remove Lifecounter
        }
        Debug.Log("You are dead!");
    }
}
