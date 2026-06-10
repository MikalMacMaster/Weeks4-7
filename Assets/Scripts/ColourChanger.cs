using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToRandomColor()
    {
      spriteRenderer.color = new Color(Random.value, Random.value, Random.value);  
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
