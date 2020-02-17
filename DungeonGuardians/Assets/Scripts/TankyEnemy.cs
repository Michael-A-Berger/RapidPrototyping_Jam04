using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankyEnemy : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = ENEMYTYPE.TANKY;
        maxHealth = 5;
        health = 5;
        speed = 1;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
