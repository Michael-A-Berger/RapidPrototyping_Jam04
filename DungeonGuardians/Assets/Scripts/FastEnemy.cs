﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = ENEMYTYPE.FAST;
        maxHealth = 2;
        health = 2;
        speed = 2;
        points = 2;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
