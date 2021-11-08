using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroAttribute : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int level = 1;
    [SerializeField] private int attack = 5;
    [SerializeField] private int exp = 0;
    [SerializeField] private int maxExp = 15;

    public Animator animator;

    private void Start()
    {
        level = 1;
        maxHealth = 50 + (15 * level);
        attack = 5 + (5 * level);
        exp = 0;
        maxExp = 15 + (10 * level);
        hp = maxHealth;
        string healthText = hp.ToString() + " / " + maxHealth.ToString();
        string expText = exp.ToString() + " / " + maxExp.ToString();
        GameObject.Find("HealthPoint").GetComponent<TMPro.TextMeshProUGUI>().text = healthText;
        GameObject.Find("ExpPoint").GetComponent<TMPro.TextMeshProUGUI>().text = expText;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        string healthText = hp.ToString() + " / " + maxHealth.ToString();
        GameObject.Find("HealthPoint").GetComponent<TMPro.TextMeshProUGUI>().text = healthText;
        animator.SetTrigger("Hit");

        if(hp <= 0)
        {
            GameObject.Find("HealthPoint").GetComponent<TMPro.TextMeshProUGUI>().text = "0 / " + maxHealth.ToString();
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("Die", true);
        GetComponent<HeroMovement>().enabled = false;
        gameObject.layer = 11;
    }

    public void AddExp(int exp)
    {
        this.exp += exp;
        string expText = this.exp.ToString() + " / " + maxExp.ToString();
        GameObject.Find("ExpPoint").GetComponent<TMPro.TextMeshProUGUI>().text = expText;
        if (this.exp >= maxExp)
        {
            this.exp -= maxExp;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        
        level += 1;
        GameObject.Find("Level").GetComponent<TMPro.TextMeshProUGUI>().text = level.ToString();
        maxHealth = 50 + (15 * level);
        attack = 5 + (5 * level);
        maxExp = 15 + (10 * level);
        hp = maxHealth;
        string healthText = hp.ToString() + " / " + maxHealth.ToString();
        string expText = this.exp.ToString() + " / " + maxExp.ToString();
        GameObject.Find("HealthPoint").GetComponent<TMPro.TextMeshProUGUI>().text = healthText;
        GameObject.Find("ExpPoint").GetComponent<TMPro.TextMeshProUGUI>().text = expText;
    }

    public int GetAttack()
    {
        return attack;
    }

    public int GetLevel()
    {
        return level;
    }
}
