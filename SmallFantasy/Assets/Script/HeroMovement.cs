using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    private float horizontalMove = 0f;

    [SerializeField] private float movementSpeed = 5f;

    private bool jump = false;
    private bool move = true;

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("AttackAnimation"))
        {
            move = false;
            horizontalMove = 0;
        }
        else
        {
            move = true;
        }
            

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attacking");
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        if(move == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        }
        jump = false;
    }

}
