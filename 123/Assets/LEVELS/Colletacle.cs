using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletacle : MonoBehaviour
{
    [SerializeField] private AudioClip bannersSound;
    int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            Audio.instance.PlaySound(bannersSound);
            
            gameObject.SetActive(false);
            BannerCollection.MyInstance.AddBanner(value);
        }
    }
}
