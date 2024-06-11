using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    public static PlayerHealth instance;
    private SpriteRenderer sr;

    private Vector2 checkPoint;

    public HealthBar healthBar;
    public Vector2 CheckPoint => checkPoint;

    public float immortalTime;
    private float immortalCounter;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // takes player maxHealth and attached to bar.
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        checkPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(immortalCounter > 0)
        {
            immortalCounter -= Time.deltaTime;
            if(immortalCounter <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }


    // Handling damage of player 
    // If it's current health will be 0, it should disappear.
    public void DealDamage()
    {
        if(immortalCounter <= 0)
        {

            currentHealth--;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0)
            {
                Die();
               
            }
            else
            {
                immortalCounter = immortalTime;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            }
        }
    }

    // take checkpoint position of player.
    public void UpdatedCheckpoint(Vector2 pos)
    {
        checkPoint = pos;
    }

    // if die, respawn it
    void Die()
    {
        Respawn();
    }

    // current health and healthbar will be max and respawn at the checkpoint.
    void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        transform.position = checkPoint; // if it tooks checkpoint respawn at checkpoint
    }
}
