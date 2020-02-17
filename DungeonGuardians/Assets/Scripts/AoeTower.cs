using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeTower : Tower
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = TOWERTYPE.AOE;
        damage = 1;
        maxTargets = 3;
        range = 3;
        attackSpeed = 1;
        attackCooldown = 1.0f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
