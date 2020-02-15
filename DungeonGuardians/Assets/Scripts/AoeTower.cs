using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeTower : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        type = TOWERTYPE.AOE;
        damage = 1;
        maxTargets = 3;
        range = 3;
        attackSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
