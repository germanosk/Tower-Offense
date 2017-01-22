﻿using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO
{
    public class Building : MonoBehaviour, IDamageable
    {
        public float life;
        public int prize;

        protected Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public bool ApplyDamage(float damage)
        {
            animator.SetTrigger("toAttack");
            life -= damage;

            bool result = life <= 0.0f;
            if (result)
            {
                animator.SetTrigger("Destroy");
                GameController.Instance.AddValue(prize);
            }
            return result;
        }
        
    }
}