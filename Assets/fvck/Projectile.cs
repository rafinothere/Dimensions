using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum ProjectileMode
    {
        PortalProjectile,
        ReverseProjectile
    }

    public static ProjectileMode CurrentMode = ProjectileMode.PortalProjectile;

    public float spawnOffset = 0.5f;
    private bool enemySpawned = false;
    public GameObject enemyPrefab;
    private float elapsedTime = 0f;
    public float speed = 10f;

    private static GameObject storedEnemyPrefab;

    void Start()
    {
        gameObject.tag = CurrentMode == ProjectileMode.PortalProjectile ? "Portal projectile" : "Reverse";
    }

    void Update()
    {
        if (CurrentMode == ProjectileMode.ReverseProjectile)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 0.5f && !enemySpawned)
            {
                StartCoroutine(SpawnEnemy());
            }
        }
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.5f);

        if (!enemySpawned && storedEnemyPrefab != null)
        {
            Instantiate(storedEnemyPrefab, transform.position, transform.rotation);
            enemySpawned = true;
        }
    }

    public void Initialize(Vector3 direction, float projectileSpeed)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CurrentMode == ProjectileMode.PortalProjectile && collision.CompareTag("Enemy"))
        {
            storedEnemyPrefab = collision.gameObject;
            Destroy(gameObject);
        }
    }

    public static void SwitchMode()
    {
        CurrentMode = CurrentMode == ProjectileMode.PortalProjectile ? 
            ProjectileMode.ReverseProjectile : ProjectileMode.PortalProjectile;
    }
}
