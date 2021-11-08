using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
                     private int hp;
    [SerializeField] private int attack;
    [SerializeField] private int exp;
    [SerializeField] private int level;

    public Animator animator;

    //public HeroAttribute attribute;
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Player").GetComponent<HeroAttribute>().GetLevel();
        maxHealth = 20 + (5 * level);
        hp = maxHealth;
        attack = 5 + (3 * level);
        exp = 5 + (3 * level);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        animator.SetTrigger("Hit");

        if(hp <= 0)
        {
            die();
        }
    }

    public void die()
    {
        animator.SetBool("Dead", true);

        GetComponent<EnemyCombat>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(2);
        
        Destroy(gameObject);
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetExp()
    {
        return exp;
    }

    public int GetAttack()
    {
        return attack;
    }

}
