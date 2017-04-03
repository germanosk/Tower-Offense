using UnityEngine;

namespace BeardTwins.TO
{
    public class Building : IDamageable
    {
        public int prize;

        protected Animator animator;

        public bool isTower =false;

        
        void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }

        public override bool ApplyDamage(float damage)
        {
            bool isDead = currentLife <= 0.0f;
            if (!isDead)
            {

                animator.SetTrigger("toAttack");
                currentLife -= damage;
                isDead = currentLife <= 0.0f;
                if (isDead)
                {
                    animator.SetTrigger("Destroy");
                    GameController.Instance.AddValue(prize);
                    if (isTower)
                    {
                        GameController.Instance.Victory();
                    }
                }
                UpdateLifeBar();
            }
            return isDead;
        }

        public override void BackToDefault()
        {
            animator.SetTrigger("Default");
        }
    }
}