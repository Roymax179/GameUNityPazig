using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool hit;
    private float direction;
    private float life;
    private void Awake()
    {
        
       
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit)
        {
            return;
        }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        life += Time.deltaTime;
        if(life > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit= true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        if(collision.tag=="Enemy")
        {
            collision.GetComponent<EnemyHP>().TakeDamage(200);
        }
    }

    public void SetDirection(float _direction)
    {
        life = 0; 
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }
    private void Dectivate()
    {
        gameObject.SetActive(false);
    }

}
