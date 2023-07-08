using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour {

        Animator anim;
        public float rotateSpeed;

        void Awake() {
                anim = GetComponent<Animator>();
        }

        //���Ĵ��ֵ�ǰ����
        public void SetAnimation(bool isLoosed) {
                anim.SetBool("isLoosed", isLoosed);
        }

        //�ƶ���ǰ����
        public void MoveTentacle(Vector2 targetPos) {

                Vector2 targetDir = (targetPos - (Vector2)transform.position).normalized;
                float targetAngle = Vector2.Angle(transform.up, targetDir);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetDir), rotateSpeed * Time.deltaTime);
                transform.Rotate(Vector3.back, targetAngle);
        }
}
