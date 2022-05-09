using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : TrapDamage
{

    [SerializeField] private float speed;
    [SerializeField] private float resettime;
    private float lifetime;
    private bool hit; 
    private Animator anim;
    private BoxCollider2D coll;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
  public void ActivateProjectile()
    {
        
        lifetime = 0;
        gameObject.SetActive(true);
       
    }
    private void Update()
    {
       
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(movementspeed, 0, 0);
        lifetime += Time.deltaTime;
        if(lifetime > resettime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        base.OnTriggerEnter2D(collision);
         gameObject.SetActive(false);

        
    }
    private void Deacitvate()
    {
        gameObject.SetActive(false);
    }
}
