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
    public bool isExplosionPiece = false; // true only for burst pieces

    void Start()
    {
        // skip auto-calculating velocity if Explode() already set it for us
        if (!isExplosionPiece)
        {
            velocity = transform.up * speed;
        }
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
            // work out an angle in radians for this piece around the circle
            float angleStep = 360f / explosionCount;
            float angle = i * angleStep * Mathf.Deg2Rad; // convert degrees to radians

            // use cos/sin to get a direction around the circle
            Vector3 dir = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);

            GameObject piece = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // apply the shared burst colour to this piece
            SpriteRenderer sr = piece.GetComponent<SpriteRenderer>();
            sr.color = burstColor;

            Firework fw = piece.GetComponent<Firework>();
            fw.timer = 0.5f;            // short life so pieces disappear quickly
            fw.canExplode = false;      // pieces don't explode again
            fw.isExplosionPiece = true; // tell this piece's Start() to leave velocity alone

            fw.velocity = dir * 3f; // set direction and speed together
        }
    }
}