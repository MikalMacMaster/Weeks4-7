using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject Canvas;
    public GameObject Item; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, Item.transform.position) <= 1.5f)
        {
            Canvas.SetActive(true);
        }
        else 
        { 
            Canvas.SetActive(false);
        }
     
    }
}
