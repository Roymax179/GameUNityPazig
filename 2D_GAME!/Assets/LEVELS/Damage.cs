using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator anim;
    private bool dead;

    [SerializeField] private float invulnerabilitiDuration;
    [SerializeField] private float Vietnameseflasback;
    private SpriteRenderer spriteRender;

    public BarHealth healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
  
    }
   public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<move>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHP(int value)
    {
        currentHealth += value;
        healthbar.SetHealth(currentHealth);
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for(int i = 0; i < Vietnameseflasback; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulnerabilitiDuration/(Vietnameseflasback * 2));
            spriteRender.color = Color.white;
            yield return new WaitForSeconds(invulnerabilitiDuration / (Vietnameseflasback * 2));
        }

        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

}
