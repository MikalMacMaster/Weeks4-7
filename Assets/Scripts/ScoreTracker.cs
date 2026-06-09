using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public Slider scoreSlider;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnSliderChanged(float scoreValue)
    {
        // Debug.Log(scoreSlider.value);
        // scoreText.text = "Score: " + scoreSlider.value;
        
        scoreText.text = "Score: " + scoreValue; 
    }
}
