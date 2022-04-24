using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_sideways : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Damage>().TakeDamage(damage);
        }
    }

    [SerializeField] private float movementdistance;
    [SerializeField] private float speed;
    private bool movingleft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementdistance;
        rightEdge = transform.position.x + movementdistance;
    }
    private void Update()
    {
        if (movingleft)
        {
            if(transform.position.x>leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingleft = true;
            }
        }
    }
}
