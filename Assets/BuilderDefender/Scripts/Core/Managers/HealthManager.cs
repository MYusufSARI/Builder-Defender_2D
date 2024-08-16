using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnDied;


    [Header(" Settings ")]
    [SerializeField] private int healthAmountMax;
    private int healthAmount;



    private void Awake()
    {
        healthAmount = healthAmountMax;
    }


    public void Damage(int damageAmount)
    {
        healthAmount -= damageAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead())
        {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }


    public bool IsDead()
    {
        return healthAmount== 0;
    }


    public int GetHealthAmount()
    {
        return healthAmount;
    }


    public float GetHealthAmountNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
}
