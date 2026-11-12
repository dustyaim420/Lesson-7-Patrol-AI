using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public float shootRate = 0.5f;
    private float cooldown = 0f;

    public Transform head;
    public Transform spawnPos;

    private float distanceToPlayer = 15f;

    public GameObject bulletPrefab;

    private Transform player;

    private void Start()
    {
        // Find player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        AimAtPlayer();
    }

    private void AimAtPlayer()
    {
        // Check distance
        if (Vector3.Distance(transform.position, player.position) <= distanceToPlayer)
        {
            // Get player's X and Z while maintaining head's Y
            Vector3 enemyLookTarget = new Vector3(
                player.position.x,
                head.position.y,
                player.position.z
            );

            // Smoothly rotate towards player
            Quaternion targetRotation = Quaternion.LookRotation(
                enemyLookTarget - head.position
            );

            head.rotation = Quaternion.Slerp(
                head.rotation,
                targetRotation,
                5f * Time.deltaTime
            );

            ShootAtPlayer();
        }
    }

    private void ShootAtPlayer()
    {
        // Check if cooldown is 0
        if (cooldown <= 0f)
        {
            // Spawn bullets from the mouth
            Instantiate(bulletPrefab, spawnPos.position, spawnPos.rotation);

            cooldown = shootRate;
        }

        cooldown -= Time.deltaTime;
    }
}