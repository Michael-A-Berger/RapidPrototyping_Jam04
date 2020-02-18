using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PLAYER player;

    [HideInInspector]
    public int points = 0;
    [HideInInspector]
    public int money = 15;

    float timer = 0.0f;
    bool moneyTick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (moneyTick && timer >= 5.0f)
        {
            AddMoney(2);
            timer = 0.0f;
        }
        if (!moneyTick && timer >= 10.0f) 
        {
            moneyTick = true;
            timer = 0.0f;
        }
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
