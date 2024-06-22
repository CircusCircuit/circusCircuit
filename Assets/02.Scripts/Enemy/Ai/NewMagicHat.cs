using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class NewMagicHat : EnemyBase
    {
        public float maxFlyDistance = 1.5f;
        Vector2 startPosition;
        protected override void Start()
        {
            base.Start();
            CancelInvoke();
            ThinkFly();
            startPosition = transform.position;
        }
        protected override void Update()
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }

            if (!isDying)
            {
                if (!isAttack)
                {
                    movement.Fly(startPosition, speed, maxFlyDistance);
                    detection.DetectPlayerInRange(5f);
                }

                if (isDetectPlayer)
                {
                    if (cooldownTimer <= 0)
                    {   
                        if (Random.value > 0.4)
                        {
                            attack.FireBullet();
                            cooldownTimer = 2f;
                        }
                        else
                        {
                            isAttack = true;
                            movement.Stop();
                            attack.FireBullet_Rapid();
                            cooldownTimer = 2f;                            
                            Invoke("EndAttack", 1f);
                        }
                    }
                }
            }
        }
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            if (collision.gameObject.layer == LayerMask.NameToLayer("Platform")){
                nextmove *= -1;
            }
        }

        public void ThinkFly()
        {
            if (nextmove == 0 )
            {
                nextmove = Random.Range(-1, 2);
            }

            if (cooldownTimer <= 0)
            {
                if (Random.value > 0.6f)
                {
                    attack.FireBullet_8();
                    cooldownTimer = 2f;
                }
            }

            Invoke("ThinkFly", 1f);
        }
        public void EndAttack(){
            isAttack=false;
        }
    }   
}
