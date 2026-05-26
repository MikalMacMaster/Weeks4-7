using UnityEngine;

public class Changer : MonoBehaviour
{
    public SpriteRenderer changerRenderer;
    public Sprite changedSprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changerRenderer.sprite = changedSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
