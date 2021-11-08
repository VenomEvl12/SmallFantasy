using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    public float attackRate = 1.2f;

    float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAttribute>().TakeDamage(GetComponent<HeroAttribute>().GetAttack());
            if(enemy.GetComponent<EnemyAttribute>().GetHp() <= 0)
            {
                GetComponent<HeroAttribute>().AddExp(enemy.GetComponent<EnemyAttribute>().GetExp());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
