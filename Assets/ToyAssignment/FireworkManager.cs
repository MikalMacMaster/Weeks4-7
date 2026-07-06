using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireworkManager : MonoBehaviour
{
    public GameObject fireworkPrefab;
    public Transform launchPoint;

    public Slider angleSlider;
    public Slider speedSlider;

    public TMP_Text angleText;
    public TMP_Text speedText;
    public TMP_Text countText;

    public Color currentColor = Color.red;

    public bool autoShoot = false;
    public float autoShootTimer = 0f;
    public float autoShootDelay = 1f;

    public int fireworkCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = launchPoint.eulerAngles;
        rotation.z = angleSlider.value;
        launchPoint.eulerAngles = rotation;

        angleText.text = "Angle: " + angleSlider.value;
        speedText.text = "Speed: " + speedSlider.value;
        countText.text = "Fireworks: " + fireworkCount;

        if (autoShoot == true)
        {
            autoShootTimer -= Time.deltaTime;

            if (autoShootTimer <= 0)
            {
                ShootFirework();
                autoShootTimer = autoShootDelay;
            }
        }
    }

    public void ShootFirework()
    {
        GameObject newFirework = Instantiate(fireworkPrefab, launchPoint.position, launchPoint.rotation);
        
        SpriteRenderer sr = newFirework.GetComponent<SpriteRenderer>();
        sr.color = currentColor;

        Rigidbody2D rb = newFirework.GetComponent<Rigidbody2D>();
        rb.linearVelocity = newFirework.transform.up * speedSlider.value;
        
        fireworkCount++;
    }

    public void ChangeColor()
    {
       currentColor = new Color(Random.value, Random.value, Random.value); 
    }

    public void ToggleAutoShoot()
    {
        autoShoot = !autoShoot;
    }
}
