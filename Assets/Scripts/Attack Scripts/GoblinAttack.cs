using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GoblinController goblin;
   

    public Animator animator;
    public float coolDown = 0.5f;
    public float coolDownTimer;
    public Transform target;

    public NavMeshAgent agent;

    void Update()
    {
        float attack_range = Vector3.Distance(target.position, transform.position);
        goblin.animator.SetBool("damage", false);
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        else if (coolDownTimer <= 0)
        {
            coolDownTimer = 0;
        }
        if (Input.GetMouseButtonDown(0) && coolDownTimer == 0)
        {
            Attack1();
            coolDownTimer = coolDown;
        }
        else if (Input.GetMouseButtonDown(1) && coolDownTimer == 0)
        {
            Attack2();
            coolDownTimer = coolDown;
        }
        else if (Input.GetMouseButtonDown(2) && coolDownTimer == 0)
        {
            Attack3();
            coolDownTimer = coolDown;
        }
    }
    void Attack1()
    {
        float attack_range = Vector3.Distance(target.position, transform.position);
        animator.SetTrigger("Attack1");
        if (attack_range <= agent.stoppingDistance)
        {

            goblin.TakeDamage();

        }

    }
    void Attack2()
    {
        float attack_range = Vector3.Distance(target.position, transform.position);
        animator.SetTrigger("Attack2");
        if (attack_range <= agent.stoppingDistance)
        {

            goblin.TakeDamage();

        }
    }
    void Attack3()
    {
        float attack_range = Vector3.Distance(target.position, transform.position);
        animator.SetTrigger("Attack3");
        if (attack_range <= agent.stoppingDistance)
        {

            goblin.TakeDamage();

        }
    }
}
