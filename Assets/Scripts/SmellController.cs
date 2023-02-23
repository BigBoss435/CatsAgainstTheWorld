using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSmell = Instantiate(weaponPrefab);
        spawnedSmell.transform.position = transform.position;
        spawnedSmell.transform.parent = transform;
    }
}
