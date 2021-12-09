using System;
using Gameplay.Weapons.Projectiles;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rocket : Projectile
{
    private float time;

    private void Start()
    {
        time = Random.Range(0, 1f) * Mathf.PI*2;
    }

    protected override void Move(float speed)
    {
        time += Time.deltaTime*8;
        
        transform.Translate(speed * Time.deltaTime * new Vector2(Mathf.Cos(time),1));
    }
    
}
