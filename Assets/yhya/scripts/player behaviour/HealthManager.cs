using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    [SerializeField] private GameObject player;

    void Update()
    {
        if (healthAmount <= 0)
        {
            DontDestroyOnLoad(player);
            SceneManager.LoadScene(0);
            healthAmount = 100f;
            healthBar.fillAmount = healthAmount / 100f;
            player.transform.position = new Vector2(-8f,0.5f);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Heal(5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(20); 
            }
        else if(collision.gameObject.CompareTag("Enemyshot"))
            {
                TakeDamage(2);
            }
        else if(collision.gameObject.CompareTag("HealthPickup"))
            {
                Heal(20);
            }
        }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

}
