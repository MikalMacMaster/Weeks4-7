using UnityEngine;

public class TankMover : MonoBehaviour
{
    public float speed;
    public float leftEdge;
    public float rightEdge; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftEdge, rightEdge);
        transform.position = pos;
    }
}
