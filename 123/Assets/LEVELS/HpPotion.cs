using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : MonoBehaviour
{
    [SerializeField] private int Hprecover;
    [SerializeField] private AudioClip HpSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Audio.instance.PlaySound(HpSound);
            collision.GetComponent<Damage>().AddHP(Hprecover);
            gameObject.SetActive(false);
        }
    }
}
