using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PLAYER player;

    int points = 0;
    int money = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int pts)
    {
        points += pts;
    }

    public void AddMoney(int mny)
    {
        money += mny;
    }

    public bool SpendMoney(int mny)
    {
        if (money - mny < 0) return false;
        else
        {
            money -= mny;
            return true;
        }
    }
}
