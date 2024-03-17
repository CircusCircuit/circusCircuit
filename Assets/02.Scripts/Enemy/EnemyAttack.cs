using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy{
    public class EnemyAttack : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public bool isDelay;
        // Start is called before the first frame update

        public void FireBullet_8( )
        {
            Debug.Log("fire!");
           
            for (int i = 0; i < 8; i++)
            {
                // 각 방향에 따른 회전 각도
                float rotation = i * 45f;

                // 총알을 회전시켜 생성합니다.
                float radius = 1f; // 반지름 값은 적절히 조정하십시오.

                // 원 주위의 랜덤한 위치 계산
                float spawnX = transform.position.x + radius * Mathf.Cos(rotation * Mathf.Deg2Rad);
                float spawnY = transform.position.y + radius * Mathf.Sin(rotation * Mathf.Deg2Rad);

                // 오브젝트 생성
                GameObject bullet = Instantiate(bulletPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
                // 총알의 초기 속도 설정
                float bulletSpeed = 10f;
                float bulletDirectionX = Mathf.Cos(Mathf.Deg2Rad * rotation);
                float bulletDirectionY = Mathf.Sin(Mathf.Deg2Rad * rotation);
                Vector2 bulletDirection = new Vector2(bulletDirectionX, bulletDirectionY).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
            }
            return;
        }
        
        public void FireBullet_16( )
        {
            Debug.Log("fire!");
           
            for (int i = 0; i < 16; i++)
            {
                // 각 방향에 따른 회전 각도
                float rotation = i * 22.5f;

                // 총알을 회전시켜 생성
                float radius = 1f; // 반지름 값 조정

                // 원 주위의 위치 계산
                float spawnX = transform.position.x + radius * Mathf.Cos(rotation * Mathf.Deg2Rad);
                float spawnY = transform.position.y + radius * Mathf.Sin(rotation * Mathf.Deg2Rad);

                // 오브젝트 생성
                GameObject bullet = Instantiate(bulletPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);
                // 총알의 초기 속도 설정
                float bulletSpeed = 10f;
                float bulletDirectionX = Mathf.Cos(Mathf.Deg2Rad * rotation);
                float bulletDirectionY = Mathf.Sin(Mathf.Deg2Rad * rotation);
                Vector2 bulletDirection = new Vector2(bulletDirectionX, bulletDirectionY).normalized;
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
            }
        }

        public void FireBullet_8_16(){
           FireBullet_8();
           isDelay = true;
           StartCoroutine(CountAttackDelay());
           if(!isDelay){
                FireBullet_16();
           }
        }    
    
        public IEnumerator CountAttackDelay()
        {
            yield return new WaitForSeconds(0.5f);
            isDelay = false;
        }
   
    }
}
