using TMPro;
using UnityEngine;

public class game_over_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshPro scoreDisplay;
    void Start()
    {
        scoreDisplay.text = "GAME OVER\n" + "Score: " + enemy_manager_script.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
