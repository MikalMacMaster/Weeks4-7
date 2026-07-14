using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireworkManager : MonoBehaviour
{
    public GameObject fireworkPrefab;
    public Transform launchPoint; // rotates with the slider
    public Transform spawnPoint;  // tip of the launcher, where fireworks actually spawn

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
        // rotate launch point based on angle slider
        Vector3 rotation = launchPoint.eulerAngles;
        rotation.z = angleSlider.value;
        launchPoint.eulerAngles = rotation;

        // update UI text each frame
        angleText.text = "Angle: " + angleSlider.value;
        speedText.text = "Speed: " + speedSlider.value;
        countText.text = "Fireworks: " + fireworkCount;

        // auto shoot countdown
        if (autoShoot == true)
        {
            autoShootTimer -= Time.deltaTime;

            if (autoShootTimer <= 0)
            {
                ChangeColor();     // new colour each auto shot
                ShootFirework();
                autoShootTimer = autoShootDelay;
            }
        }
    }

    // Shoot button
    public void ShootFirework()
    {
        GameObject newFirework = Instantiate(fireworkPrefab, spawnPoint.position, launchPoint.rotation);

        SpriteRenderer sr = newFirework.GetComponent<SpriteRenderer>();
        sr.color = currentColor;

        Firework fw = newFirework.GetComponent<Firework>();
        fw.speed = speedSlider.value;

        fireworkCount++;
    }

    // Change Colour button
    public void ChangeColor()
    {
        currentColor = new Color(Random.value, Random.value, Random.value);
    }

    // Auto Shoot toggle button
    public void ToggleAutoShoot()
    {
        autoShoot = !autoShoot;
    }
}