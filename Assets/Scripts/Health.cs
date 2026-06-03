using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject Enemy;
    public int health; 
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool leftMouseWasPressed = Mouse.current.leftButton.wasPressedThisFrame;

        if (leftMouseWasPressed) 
        { 
        health = health - 1;
        }

        if (health < 0) 
        {
            Destroy(Enemy);
        }
    }

 
    
}
