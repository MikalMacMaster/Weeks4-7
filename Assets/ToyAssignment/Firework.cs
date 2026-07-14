using UnityEngine;

public class Firework : MonoBehaviour
{
    public float timer = 3f;
    public float speed = 5f;
    public float gravity = 2f;

    public GameObject explosionPrefab;
    public int explosionCount = 8;
    public bool canExplode = true;

    public Vector3 velocity;

    void Start()
    {
        // store initial direction and speed as a velocity vector
        velocity = transform.up * speed;
    }

    void Update()
    {
        // apply a simple gravity pull downward each frame
        velocity += Vector3.down * gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        // count down until it's time to destroy this firework
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Explode();          // spawn the burst pieces first
            Destroy(gameObject); // then remove this firework
        }
    }

    void Explode()
    {
        if (!canExplode) return; // stop exploded pieces from exploding again

        // pick one random colour for this whole burst
        Color burstColor = new Color(Random.value, Random.value, Random.value);

        for (int i = 0; i < explosionCount; i++)
        {
            // spread pieces out evenly in a circle of directions
            float angle = i * (360f / explosionCount);
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;

            GameObject piece = Instantiate(explosionPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, dir));

            // apply the shared burst colour to this piece
            SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
            sr.color = burstColor;

            Firework fw = piece.GetComponent<Firework>();
            fw.speed = 3f;
            fw.timer = 0.5f;       // short life so pieces disappear quickly
            fw.canExplode = false; // pieces don't explode again
        }
    }
}