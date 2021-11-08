using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    private bool delayAttack = false;

    public float attackRate = 2f;

    float nextAttackTime = 0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(delayAttack == false)
        {
            delayAttack = true;
            StartCoroutine(setDelayToFalse());
            if (GetComponent<EnemyMovement>().GetIsInAttackRadius())
            {
                if (Time.time >= nextAttackTime)
                {
                    attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<HeroAttribute>().TakeDamage(GetComponent<EnemyAttribute>().GetAttack() / 2 );
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator setDelayToFalse()
    {
        yield return new WaitForSeconds(1);
        delayAttack = false;
    }
}
