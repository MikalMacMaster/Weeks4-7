using UnityEngine;
using TMPro;

public class ImageHoverDescription : MonoBehaviour
{
    [TextArea]
    public string description;

    public TextMeshProUGUI descriptionText;
    public GameObject descriptionBox;

    void OnMouseEnter()
    {
        descriptionBox.SetActive(true);
        descriptionText.text = description;
    }

    void OnMouseExit()
    {
        descriptionBox.SetActive(false); 
    }
    void Start()
    {
        descriptionBox.SetActive(false);
    }

    
    void Update()
    {
        
    }
}
