using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float activeTime;
    [SerializeField] private float waitTime;
    [SerializeField] private AudioClip firesound;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool trigger;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(!trigger)
            {
                StartCoroutine(ActivateFiretrap());

            }
            if (active)
            {
                collision.GetComponent<Damage>().TakeDamage(damage);
            }
        }

    }
    private IEnumerator ActivateFiretrap()
    {
        trigger = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        Audio.instance.PlaySound(firesound);
        spriteRend.color = Color.white ;
        active =true;
        anim.SetBool("active", true);
        yield return new WaitForSeconds(activeTime);
        active=false;
        trigger=false;
        anim.SetBool("active", false);
    }
}
