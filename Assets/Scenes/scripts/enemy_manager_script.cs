using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class enemy_manager_script : MonoBehaviour
{
    public static enemy_manager_script instance;
    public List<EnemyController> enemies;
    //enemies
    public GameObject enemy1;
    //timer
    public float startTimer;
    private float timer;
    //score
    private static int score = 0;
    public TextMeshPro scoreDisplay;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    
    void Start()
    {
        timer = startTimer;
        scoreDisplay.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(enemy1, new Vector3(0, 4, 0), transform.rotation);
            timer = startTimer;
        }
        scoreDisplay.text = "Score: " + score;
        Debug.logger.Log(enemies.Count);
    }
    public class EnemyController : MonoBehaviour
    {
        public void Start()
        {
            enemy_manager_script.instance.enemies.Add(this);
        }

        public void OnDestroy()
        {
            enemy_manager_script.instance.enemies.Remove(this);
            score += 100;
        }
    }
}


