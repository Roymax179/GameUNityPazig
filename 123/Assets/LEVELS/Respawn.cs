using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private AudioClip respawnsound;
    [SerializeField] private Transform respawn;
    private Damage playerHp;

    private void Awake()
    {
        playerHp = GetComponent<Damage>();
    }

    public void res()
    {
        playerHp.Respawn();
        this.transform.position = respawn.position;
        Audio.instance.PlaySound(respawnsound);
    }
   
}
