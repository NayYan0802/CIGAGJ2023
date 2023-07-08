using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour {

        Animator anim;
        public float rotateSpeed;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //更改触手当前动画
    public void SetAnimation(bool isLoosed) {
                anim.SetBool("isLoosed", isLoosed);
        }

        //移动当前触手
        public void MoveTentacle(Vector2 targetPos) {

        Vector2 targetDir = ((Vector2)targetPos - (Vector2)transform.localPosition).normalized;
        float targetAngle = Vector2.Angle(transform.up, targetDir);
        if (transform.rotation.z < 0)
        {
            if (targetDir.x < 0|| Vector2.Angle(transform.up, Vector2.up) > Vector2.Angle(targetDir, Vector2.up)&& targetDir.x > 0)
            {
                targetAngle *= -1;
            }
        }
        else
        {
            if(targetDir.x < 0&& Vector2.Angle(transform.up, Vector2.up) < Vector2.Angle(targetDir, Vector2.up))
            {
                targetAngle *= -1;
            }
        }
        //transform.Rotate(Vector3.back, targetAngle);
        float startLength = transform.localScale.y;
                float targetLength = Vector2.Distance(targetPos, transform.position) * 0.2f;
                StartCoroutine(TentacleAni(startLength, targetLength, targetAngle, 0.3f));
        }

        private IEnumerator TentacleAni(float startLength, float targetLength, float targetAngle, float time) {
                float timer = 0f;
                while (timer <= time) 
        {            
                        timer += Time.deltaTime;
                        transform.Rotate(Vector3.back, targetAngle * Time.deltaTime / time);
                        Vector3 newScale = transform.localScale;
                        newScale.y = Mathf.Lerp(startLength, targetLength, timer / time);
                        transform.localScale = newScale;
                        yield return null;
                }
        }
}
