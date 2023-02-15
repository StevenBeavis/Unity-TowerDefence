
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    //personal
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    public float health;
    public int killValue = 50;

    private bool isDead = false;


    public GameObject deathEffect;

    private Transform target;

    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void takeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <=0 && !isDead)
        {
            Die();
        }
    
    }
    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    
    }
    void Die() 
    {
        isDead = true;

        PlayerStats.Money += killValue;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemyCount--;

        Destroy(gameObject);
    }

    
}
