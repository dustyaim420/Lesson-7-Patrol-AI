using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float delayTime = 3f;

    private void Start()
    {
        // Destroy bullet after delay time regardless of hit
        Destroy(gameObject, delayTime);
    }

    private void Update()
    {
        // Move along the Z axis
        transform.Translate(0f, 0f, bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if bullet hits player
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}