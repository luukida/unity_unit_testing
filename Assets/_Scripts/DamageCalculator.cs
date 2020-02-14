using UnityEngine;
using System;

public class DamageCalculator
{
    public float calculate(float health, float damage, float defense, bool critical) {
        if (health < 0 || damage < 0|| defense < 0)
            throw new ArgumentOutOfRangeException("One of the parameter is less than zero");

        float remainingHealth = 0;

        if (defense - damage > 0 && !critical) {
          return health;
        }
        remainingHealth = critical ? health - (damage  * 2) : health - (damage - defense);
        
        return remainingHealth < 0 ? 0 : remainingHealth;
    }
}