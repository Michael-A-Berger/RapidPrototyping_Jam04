using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        type = ENEMYTYPE.FAST;
        health = 2;
        speed = 2;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
