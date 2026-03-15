using UnityEngine;
using TMPro;

public class health_script : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public movement_script movementScript;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "Health " + movementScript.health.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health " + movementScript.health.ToString("F0");
    }
}
