using UnityEngine;

public class Runner : MonoBehaviour
{
    public float speed;

    bool isMoving = false;
    bool isStopped = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (isStopped == true)
        {
           

        }

    }

    public void OnMoveClick()
    {
        isMoving = true;
    }

    public void OnStopClick()
    { 
      
    }
}
