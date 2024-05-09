using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Transform alvo;

    private Animator animator;

    private void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;

        if (alvo == null )
        {
            Debug.LogError("Player não encontrado na cena");
        }

        animator = GetComponent<Animator>();
        EnemyDie();
    }
    private void Update()
    {
        if ( alvo != null )
        {
            Vector3 direction = (alvo.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            transform.LookAt(alvo);
        }
    }

    public void EnemyDie()
    {
        animator.SetTrigger("Morte");
    }
}
