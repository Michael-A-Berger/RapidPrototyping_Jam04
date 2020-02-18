using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    Player player1;
    Player player2;
    GameObject endTextObj;

    TextMeshPro p1Text = null;
    TextMeshPro p2Text = null;
    TextMeshPro endText = null;

    public float timerMax = 150f;
    float timer;
    bool end;
    bool playersLost = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponent<Player>().player == PLAYER.PLAYER1)
                player1 = player.GetComponent<Player>();
            if (player.GetComponent<Player>().player == PLAYER.PLAYER2)
                player2 = player.GetComponent<Player>();
        }

        p1Text = transform.GetChild(1).GetComponentInChildren<TextMeshPro>();
        p2Text = transform.GetChild(2).GetComponentInChildren<TextMeshPro>();
        endText = transform.GetChild(3).GetComponent<TextMeshPro>();
        endTextObj = transform.GetChild(3).gameObject;
        endTextObj.SetActive(false);
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            p1Text.text = "- " + player1.money;
            p2Text.text = "- " + player2.money;

            timer += Time.deltaTime;
            if (timer >= timerMax || playersLost)
            {
                end = true;

                foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
                {
                    if (obj.tag != "MainCamera" && obj.tag != "Light" && obj.tag != "AudioManager" && obj.tag != "UIManager")
                        obj.SetActive(false);
                }

                endTextObj.SetActive(true);

                if (player1.points > player2.points)
                    endText.text = "Player 1 wins \n Score: " + (player1.points);
                else if (player2.points > player1.points)
                    endText.text = "Player 2 wins \n Score: " + (player2.points);
                else if (!playersLost)
                    endText.text = "It's a tie!!!";
                else
                    endText.text = "You Lose";
            }
        }

    }

    // AllPlayersLose()
    public void AllPlayersLose()
    {
        playersLost = true;
    }
}
