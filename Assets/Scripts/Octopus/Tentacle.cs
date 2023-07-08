using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour {

        Animator anim;
        public float rotateSpeed;

        void Awake() {
                anim = GetComponent<Animator>();
        }

        //更改触手当前动画
        public void SetAnimation(bool isLoosed) {
                anim.SetBool("isLoosed", isLoosed);
        }

        //移动当前触手
        public void MoveTentacle(Vector2 targetPos) {

                Vector2 targetDir = (targetPos - (Vector2)transform.position).normalized;
                float targetAngle = Vector2.Angle(transform.up, targetDir);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetDir), rotateSpeed * Time.deltaTime);
                transform.Rotate(Vector3.back, targetAngle);
        }
}
