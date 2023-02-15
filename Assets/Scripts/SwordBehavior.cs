using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : ProjectileWeapon
{
    Sword sword;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        sword = FindAnyObjectByType<Sword>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * sword.speed * Time.deltaTime;
    }
}
