using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public static int score = 0;
    public TextMeshPro scoreDisplay;
    //player
    public movement_script movement_script;

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
        //Debug.logger.Log(enemies.Count);
        
        if (movement_script.health <= 0)
        {
            StartCoroutine("gameover");
        }
    }
    
    IEnumerator gameover()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
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


