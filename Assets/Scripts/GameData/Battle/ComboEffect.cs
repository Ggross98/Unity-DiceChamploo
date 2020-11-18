using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboEffect
{

    public enum EffectType { Damage, Shield, Heal };

    public EffectType type = EffectType.Damage;

    public int value = 1;

    public bool toEnemy = true;

    public bool isAreaEffect = false;

    public ComboEffect() { }

    public ComboEffect(EffectType eff, int v, bool enemy, bool aoe)
    {
        type = eff;

        value = v;

        toEnemy = enemy;

        isAreaEffect = aoe;
    }
    
}
