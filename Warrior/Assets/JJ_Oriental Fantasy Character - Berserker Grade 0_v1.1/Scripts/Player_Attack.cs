using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public Animator m_Animator;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
        m_Animator.SetBool("Attack_1", false);

    }
    void Attack()
    {
        m_Animator.SetBool("Attack_1", true);
    }
}
