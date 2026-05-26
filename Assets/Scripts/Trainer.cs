using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Trainer : MonoBehaviour
{
    public SpriteRenderer creatureRenderer;
    public Camera gameCamera;
    public Color caughtColour;

    public List<SpriteRenderer> uncaughtCreatures;
    public List<SpriteRenderer> caughtCreatures;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        if (isClicked)
        {
            //caughtCreatures:
            //for each element I want to output that to the console

            //FIRST SECTION: Define and set the value of the iterator
            //SECOND SECTION: Define when the loop will stop
            //THIRD SECTION: Increase the value of i each time it loops

            for (int i = 0; i > caughtCreatures.Count; i++)
            {

            }


            if (caughtCreatures.Count > 0)
            {
                Debug.Log(caughtCreatures[0]);
            }

        }


        if (isClicked && creatureRenderer.bounds.Contains(worldMousePosition))
        {
            creatureRenderer.color = caughtColour;

            bool isCreatureCaught = caughtCreatures.Contains(creatureRenderer);
            //Debug.Log("Is creature caught["+isCreatureCaught.ToString()+"]");
            if (!isCreatureCaught)
            {
                caughtCreatures.Add(creatureRenderer);
            }

            uncaughtCreatures.Remove(creatureRenderer);
        }
    }
}