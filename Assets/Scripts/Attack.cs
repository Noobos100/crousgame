using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator m_animator;
    public SphereCollider m_attackCollider;
    public bool m_isAttacking = false;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        // press F key to trigger the attack animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_animator.SetTrigger("Attack");
            StartCoroutine(AttackCorroutine());
        }

    }

    private IEnumerator AttackCorroutine(){

        m_attackCollider.enabled = true;
        m_isAttacking = true;
        yield return new WaitForSeconds(2.5f);
        m_attackCollider.enabled = false;
        m_isAttacking = false;
    }
}
