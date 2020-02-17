using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        type = TOWERTYPE.Arrow;
        damage = 1;
        maxTargets = 1;
        range = 3;
        attackSpeed = 1;
        cost = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
