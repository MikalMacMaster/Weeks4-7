using UnityEngine;

namespace Practice_Midterm
{
    public class Orbit : MonoBehaviour
    {
        public Transform alphaTransform;
        public Transform betaTransform;
        public Transform charlieTransform;
        public Transform deltaTransform;
        public Transform echoTransform;
        public Transform foxtrotTransform;

        public float rotationSpeed;

        // Update is called once per frame
        void Update()
        {
            //alphaTransform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            //betaTransform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            //charlieTransform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            //deltaTransform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            echoTransform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            //foxtrotTransform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }
    }
}

