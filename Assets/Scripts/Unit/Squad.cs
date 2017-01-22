using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO
{
    public class Squad : MonoBehaviour, IDamageable
    {
        public List<Unit> units;

        public float speed;
        [Tooltip("How many seconds should wait for the next atack")]
        public float atackInterval;
        public float damage;
        public float armor;
        public float life;

        protected float nextAtackTime;

        protected int destinationId = -1;

        protected IDamageable currentTarget;

        protected new Rigidbody2D rigidbody2D;

        protected Animator animator;

        public List<Vector3> waypoints;

        public void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            if (waypoints.Count > 0)
            {
                destinationId = 0;
            }

        }

        public void Update()
        {
            
            if(currentTarget != null  )
            {
                if(nextAtackTime <= Time.time)
                {
                    Atack();
                }
            } else if (destinationId > -1)
            {
                Move();
            }
        }
        public void Move()
        {
            Move(waypoints[destinationId]);
        }
        
        public void Move(Vector3 target)
        {
            Vector3 movement = target - transform.position;
            rigidbody2D.velocity = movement.normalized * speed;
        }

        public bool ApplyDamage(float damage)
        {
            life -= damage - armor;
            bool result = life <= 0.0f;
            if (result)
            {
                animator.SetTrigger("Die");
            }
            return result;
        }

        public void Atack()
        {
            nextAtackTime = Time.time + atackInterval;
            if (currentTarget.ApplyDamage(damage))
            {
                currentTarget = null;
                rigidbody2D.isKinematic = false;
                
                animator.SetTrigger("Move");
            }
        }

        public void AquireTarget(IDamageable target)
        {
            animator.SetTrigger("Atack");
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.isKinematic = true;
            currentTarget = target;
            Atack();
        }
        
        public void OnCollisionEnter2D(Collision2D coll)
        {
            if(currentTarget == null)
            {
                if (coll.gameObject.CompareTag("Enemy"))
                {
                    Squad enemy = coll.gameObject.GetComponent<Squad>();
                    AquireTarget(enemy);
                    enemy.AquireTarget(this);

                    Debug.Log(gameObject.name + " velocity at collision " + rigidbody2D.velocity);
                }
                if (coll.gameObject.CompareTag("Building"))
                {
                    Building enemy = coll.gameObject.GetComponent<Building>();
                    AquireTarget(enemy);

                    Debug.Log(gameObject.name + " is attackin " + coll.gameObject.name);
                }
            }

        }
        public void Dispose()
        {
            gameObject.SetActive(false);
        }
    }
}