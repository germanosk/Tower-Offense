using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO
{
    public class Squad : MonoBehaviour, IDamageable
    {
        public List<Unit> units;

        public float speed;
        public float rateOfAtack;
        public float damage;
        public float armor;
        public float life;

        protected float nextAtackTime;
        protected float atackInterval;

        protected int destinationId = -1;

        protected IDamageable currentTarget;

        protected new Rigidbody2D rigidbody2D;

        public List<Vector3> waypoints;

        public void Start()
        {

            rigidbody2D = GetComponent<Rigidbody2D>();
            if (waypoints.Count > 0)
            {
                destinationId = 0;
            }
            atackInterval = rateOfAtack/60.0f;

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
            return life <= 0.0f;
        }

        public void Atack()
        {
            nextAtackTime = Time.time + atackInterval;
            if (currentTarget.ApplyDamage(damage))
            {
                currentTarget = null;
            }
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void OnCollisionEnter2D(Collision2D coll)
        {
            if(currentTarget == null)
            {
                if (coll.gameObject.tag == gameObject.tag)
                {
                    rigidbody2D.velocity = Vector2.zero;
                    currentTarget = coll.gameObject.GetComponent<Squad>() as IDamageable;
                    Atack();

                    Debug.Log(gameObject.name + " velocity at collision " + rigidbody2D.velocity);
                }
            }

        }
    }
}