using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] private AudioClip sound;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Damage>().TakeDamage(damage);
            Audio.instance.PlaySound(sound);
        }
    }
}
