using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        type = ENEMYTYPE.WEAK;
        health = 3;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
