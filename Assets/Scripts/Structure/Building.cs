using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO
{
    public class Building : MonoBehaviour, IDamageable
    {
        public float life;
        public int prize;

        protected Animator animator;

        public bool isTower =false;
        

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public bool ApplyDamage(float damage)
        {
            bool isDead = life <= 0.0f;
            if (!isDead)
            {

                animator.SetTrigger("toAttack");
                life -= damage;
                isDead = life <= 0.0f;
                if (isDead)
                {
                    animator.SetTrigger("Destroy");
                    GameController.Instance.AddValue(prize);
                    if (isTower)
                    {
                        GameController.Instance.Victory();
                    }
                }
            }
            return isDead;
        }
        
    }
}