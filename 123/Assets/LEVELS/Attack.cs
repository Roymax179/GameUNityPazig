
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float meleeCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballsSound;
    [SerializeField] private AudioClip meleeAttackSound;
    private Animator anim;
    private move movement;
    private float cooldownTimer = Mathf.Infinity;
    private float meleeTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<move>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            playerAttack();
        }
        //if (Input.GetMouseButton(1) && meleeTimer > meleeCooldown && movement.canAttack())
        //{
        //    playerMeleeAttack();
        //}
        cooldownTimer += Time.deltaTime;
        //meleeTimer += Time.deltaTime;
    }

    private void playerAttack()
    {
       Audio.instance.PlaySound(fireballsSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private void playerMeleeAttack()
    {
        Audio.instance.PlaySound(meleeAttackSound);
        anim.SetTrigger("meleeattack");
        meleeTimer = 0;
        
        
    }
    
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
