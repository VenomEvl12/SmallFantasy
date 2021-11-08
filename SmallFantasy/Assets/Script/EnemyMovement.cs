using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 1f;
    private Vector3 startPosition;
    [SerializeField]private float maxWandering = 4f;
    private Vector3 targetPosition;
    [SerializeField] private Animator animator;
    private float iddleTime;

    private Vector3 player;

    public GameObject playerObject;

    private bool wandering = false;
    private bool facingRight = true;
    private float radiusToPlayer;
    private bool hit = false;
    private bool iddle = false;

    private bool inAttackRadius = false;

    // Start is called before the first frame update
    void Start()
    {
        if(playerObject == null)
        {
            playerObject = GameObject.Find("Player");
        }
        startPosition = transform.position;
    }


    void Update()
    {
        player = playerObject.transform.position;
        player.y = startPosition.y;

        float playerDistance = player.x - startPosition.x;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("GolemHit"))
        {
            hit = true;
        }
        else
        {
            hit = false;
        }

        if(playerDistance <= 4 && playerDistance >= -4)
        {
            if(hit == false)
            {
                if(player.x - transform.position.x < 0 && facingRight == true)
                {
                    Flip();
                }else if(player.x - transform.position.x > 0 && facingRight == false)
                {
                    Flip();
                }
                wandering = false;
                if(player.x - transform.position.x > -0.5f && player.x - transform.position.x < 0.5f)
                {
                    inAttackRadius = true;
                    animator.SetFloat("Speed", 0);
                }
                else
                {
                    inAttackRadius = false;
                }
                if (!inAttackRadius)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player, movementSpeed * Time.deltaTime);
                    animator.SetFloat("Speed", movementSpeed);
                }
            }
        }

        if (wandering == false && (playerDistance > 4 || playerDistance < -4)) 
        {
            if(iddle == false)
            {
                targetPosition = new Vector3(startPosition.x + Random.Range(-maxWandering, maxWandering), startPosition.y, startPosition.z);
                animator.SetFloat("Speed", 0);
                if (targetPosition.x - transform.position.x > 0 && facingRight == false)
                {
                    Flip();
                }else if(targetPosition.x - transform.position.x < 0 && facingRight == true)
                {
                    Flip();
                }
                wandering = true;
            }
        }

        if(transform.position.x == targetPosition.x && (playerDistance > 4 || playerDistance < -4))
        {
            wandering = false;
            iddle = true;
            StartCoroutine(Idle(Random.Range(2, 4)));
            animator.SetFloat("Speed", 0);
        }

        if(wandering == true)
        {
            if(hit == false)
            {
                if (iddle == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                    animator.SetFloat("Speed", movementSpeed);
                }
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator Idle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        iddle = false;
    }

    public bool GetIsInAttackRadius()
    {
        return inAttackRadius;
    }
}
