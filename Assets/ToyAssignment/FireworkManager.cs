using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireworkManager : MonoBehaviour
{
    public GameObject fireworkPrefab;
    public Transform launchPoint;
    public Transform spawnPoint;

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

    void Update()
    {
        // rotate the launch point based on the angle slider
        Vector3 rotation = launchPoint.eulerAngles;
        rotation.z = angleSlider.value;
        launchPoint.eulerAngles = rotation;

        // keep the UI text updated with current values
        angleText.text = "Angle: " + angleSlider.value;
        speedText.text = "Speed: " + speedSlider.value;
        countText.text = "Fireworks: " + fireworkCount;

        // handle the auto shoot timer
        if (autoShoot == true)
        {
            autoShootTimer -= Time.deltaTime;

            if (autoShootTimer <= 0)
            {
                ChangeColor();     // pick a new random colour for this shot
                ShootFirework();
                autoShootTimer = autoShootDelay;
            }
        }
    }

    // called by the Shoot button
    public void ShootFirework()
    {
        GameObject newFirework = Instantiate(fireworkPrefab, spawnPoint.position, launchPoint.rotation);

        // get the sprite renderer on the new firework and set its colour
        SpriteRenderer sr = newFirework.GetComponent<SpriteRenderer>();
        sr.color = currentColor;

        // get the firework script on the new firework and set its speed
        Firework fw = newFirework.GetComponent<Firework>();
        fw.speed = speedSlider.value;

        fireworkCount++;
    }

    // called by the Change Colour button
    public void ChangeColor()
    {
        currentColor = new Color(Random.value, Random.value, Random.value);
    }

    // called by the Auto Shoot toggle button
    public void ToggleAutoShoot()
    {
        autoShoot = !autoShoot;
    }
}



