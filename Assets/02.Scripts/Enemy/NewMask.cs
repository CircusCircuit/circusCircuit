using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class NewMask : EnemyBase
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.fixedDeltaTime;
            }

            if (!isDying)
            {   
                if(cooldownTimer <= 0){
                    GroundMove(1.5f);
                    detection.DetectPlayerInRange(5f);
                }

                if (isDetectPlayer)
                {
                    if(cooldownTimer <= 0){
                        attack.FireBullet_Circle12();
                        cooldownTimer = 3f;
                    }
                }

            }
        }
    }
    
}
