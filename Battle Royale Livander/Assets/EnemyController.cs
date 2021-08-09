using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Health health;
    private CapsuleCollider collider;

    [Header("Animation")]
    public Animator animator;

    private void Awake()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health.Dead += Dead;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        collider.enabled = false;
        animator.SetTrigger("Dead");
    }
}
