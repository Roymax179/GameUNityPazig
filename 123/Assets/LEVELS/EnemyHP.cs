using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    

    public int maxHealth = 100;
    public int currentHealth;

    private Animator anim;
    private bool dead;

    [SerializeField] private float invulnerabilitiDuration;
    [SerializeField] private float Vietnameseflasback;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip die;
    private SpriteRenderer spriteRender;

    
    void Start()
    {
        currentHealth = maxHealth;
       ;
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            Audio.instance.PlaySound(hurt);
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponentInParent<EnemyPatrol>().enabled = false;
                GetComponent<MeleEnemy>().enabled = false;
                GetComponent<RangeEnemy>().enabled = false;
                dead = true;
                Audio.instance.PlaySound(die);
            }
        }
    }
    public void AddHP(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < Vietnameseflasback; i++)
        {
            spriteRender.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulnerabilitiDuration / (Vietnameseflasback * 2));
            spriteRender.color = Color.white;
            yield return new WaitForSeconds(invulnerabilitiDuration / (Vietnameseflasback * 2));
        }

        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
