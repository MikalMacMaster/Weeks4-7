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
    public bool isExplosionPiece = false; // true for burst pieces, false for the main firework

    void Start()
    {
        // don't overwrite velocity if Explode() already set it
        if (!isExplosionPiece)
        {
            velocity = transform.up * speed;
        }
    }

    void Update()
    {
        // fake gravity so it arcs instead of going straight
        velocity += Vector3.down * gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        // countdown to explosion/destroy
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        if (!canExplode) return; // stop pieces from exploding again

        // whole burst shares one random colour
        Color burstColor = new Color(Random.value, Random.value, Random.value);

        for (int i = 0; i < explosionCount; i++)
        {
            // spread pieces evenly around a circle
            float angleStep = 360f / explosionCount;
            float angle = i * angleStep * Mathf.Deg2Rad; // Sin/Cos need radians

            Vector3 dir = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);

            GameObject piece = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
            sr.color = burstColor;

            Firework fw = piece.GetComponent<Firework>();
            fw.timer = 0.5f;            // short life so pieces fizzle fast
            fw.canExplode = false;      // no chain explosions
            fw.isExplosionPiece = true; // skip velocity overwrite in Start()

            fw.velocity = dir * 3f; // send it out in its direction
        }
    }
}