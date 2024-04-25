using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimations
{
    //Makes a sprite flash red.
    public IEnumerator NormalDamage(SpriteRenderer sprite, float damageFlashTime)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(damageFlashTime);
        sprite.color = Color.white;
    }
}
