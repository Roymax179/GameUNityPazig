using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private AudioClip arrow;
    private float cooldownTimer;

    private void Attack()
    {

        cooldownTimer = 0;
        Audio.instance.PlaySound(arrow);
        arrows[FindFireball()].transform.position = firePoint.position;
        arrows[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(cooldownTimer >= cooldown)
        {
            Attack();
        }
    }

    private int FindFireball()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
