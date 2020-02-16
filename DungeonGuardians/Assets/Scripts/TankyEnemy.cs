using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankyEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        type = ENEMYTYPE.TANKY;
        health = 5;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
