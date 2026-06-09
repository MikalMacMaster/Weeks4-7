using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthbarFillImage;

    public float currentHealth = 100f;
    public float maxHealth = 100f;

    public SpriteRenderer enemyRenderer;
    public AudioSource damageSound; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0;

        bool isMouseClicked = Mouse.current.leftButton.wasReleasedThisFrame;
        bool isMouseOverEnemy = enemyRenderer.bounds.Contains(worldMousePosition);
        bool shouldTakeDamage = isMouseOverEnemy && isMouseClicked;

        if (shouldTakeDamage)
        {
            damageSound.Play();
            currentHealth -= 5f;
            if (currentHealth <= 0f)
            { 
            enemyRenderer.gameObject.SetActive(false);
            }

            healthbarFillImage.fillAmount = currentHealth / maxHealth;
        }

    }
}