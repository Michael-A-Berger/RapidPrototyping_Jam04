using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = TOWERTYPE.Arrow;
        damage = 3;
        maxTargets = 1;
        range = 2;
        attackSpeed = 1;
        cost = 15;
        attackCooldown = 1.0f;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
