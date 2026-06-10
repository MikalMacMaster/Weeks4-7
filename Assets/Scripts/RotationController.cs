using UnityEngine;

public class RotationController : MonoBehaviour
{
    public void ChangeRotation(float value)
    {
        transform.eulerAngles = new Vector3(0, 0, value);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
