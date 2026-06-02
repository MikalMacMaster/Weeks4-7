using UnityEngine;

namespace Practice_Midterm
{
    public class Spawner : MonoBehaviour
    {
        public GameObject alphaPrefab;
        public GameObject betaPrefab;
        public GameObject charliePrefab;
        public GameObject deltaPrefab;
        public GameObject echoPrefab;

        public float spawnFrequency;

        private float progress = 0f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            progress += Time.deltaTime;
            if(progress > spawnFrequency)
            {
                GameObject spawnedObject = null;
                //spawnedObject = Instantiate(alphaPrefab);
                spawnedObject = Instantiate(betaPrefab);
                //spawnedObject = Instantiate(charliePrefab);
                //spawnedObject = Instantiate(deltaPrefab);
                //spawnedObject = Instantiate(echoPrefab);

                Mover spawnedMover = spawnedObject.GetComponent<Mover>();
                spawnedMover.speed = 3f;
                progress = 0f;
            }
        }
    }
}
