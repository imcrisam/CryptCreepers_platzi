﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int difficulty = 1;
    public int time = 30;
    int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            if (score % 10 == 0)
            {
                difficulty++;
            }
        }
    }
    bool gameOver = false;
    public bool GameOver
    {
        get => gameOver;
        set
        {
            gameOver = value;
            if (gameOver)
            {
                StopCoroutine(CountDownTime());
                Invoke("GameOverReset", 0.5f);
            }
        }
    }




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(CountDownTime());
    }

    void DestroyAllEnemies()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in enemies)
        {
            Destroy(item);
        }
    }

    void GameOverReset()
    {
        IUManager.instance.GameOver();
        DestroyAllEnemies();
    }


    IEnumerator CountDownTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        GameManager.instance.GameOver = true;
    }



}
