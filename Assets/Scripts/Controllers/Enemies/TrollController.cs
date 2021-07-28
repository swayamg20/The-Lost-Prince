using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrollController : MonoBehaviour
{
    // Start is called before the first frame update
    public float lookRadius = 10f;
    public bool isAttack;
    public Player_Dodge_Hit_Die player_Dodge;
    public Transform target;
    //public HealthBar healthbar;
    NavMeshAgent agent;
    public Animator animator;

    public float coolDown = 1f;
    public float coolDownTimer = 1f;

    public int maxhealth = 100;
    public int currenthealth;

    public GameObject gameobject;

    public float deathCoolDown = 1f;
    public float deathTimer;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && !isDead)
        {
            agent.SetDestination(target.position);
            animator.SetBool("attack03", false);
            animator.SetBool("walk", true);
            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("walk", false);
                FaceTarget();
                //animator.SetBool("attack", true);
                if (coolDownTimer > 0)
                {
                    coolDownTimer -= Time.deltaTime;
                }
                else if (coolDownTimer <= 0)
                {
                    coolDownTimer = 0;
                }
                if (coolDownTimer == 0)
                {


                    EnemyAttack();
                    coolDownTimer = coolDown;
                }
            }
        }
    }
    public void EnemyAttack()
    {
        isAttack = true;

        player_Dodge.takeDamage(40);
        animator.SetBool("attack03", true);
        
    }
    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    public void TakeDamage()
    {
        currenthealth -= 40;
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            Death();
        }
        animator.SetBool("damage", true);
    }
    public void Death()
    {
        animator.SetBool("dead", true);
        isDead = true;
       
    }
}
