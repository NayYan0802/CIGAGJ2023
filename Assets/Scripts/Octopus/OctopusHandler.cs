using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHandler : MonoBehaviour {
        //�����ɿ������ӵ��¼�����
        private Subscription<TentacleLoose> TentacleLooseSub;
        private Subscription<TentacleTouch> TentacleTouchSub;

        public List<Transform> tentacleList;

        void Start() {
                TentacleLooseSub = EventBus.Subscribe<TentacleLoose>(TentacleLooseFunc);
                TentacleTouchSub = EventBus.Subscribe<TentacleTouch>(TentacleTouchFunc);
        }

        //�����ɿ��¼�ִ�еķ���
        void TentacleLooseFunc(TentacleLoose tentacleLoose) {
                tentacleList[tentacleLoose.tentacleIndex].GetComponent<Tentacle>().SetAnimation(true);
        }
        //���������¼�ִ�еķ���
        void TentacleTouchFunc(TentacleTouch tentacleTouch) {
                //tentacleList[tentacleTouch.tentacleIndex].GetComponent<Tentacle>().MoveTentacle(tentacleTouch.targetPos);
                tentacleList[tentacleTouch.tentacleIndex].GetComponent<Tentacle>().SetAnimation(false);
        }



        //�¼��ͷŵĻ���
        void OnDestroy() {
                EventBus.Unsubscribe(TentacleLooseSub);
                EventBus.Unsubscribe(TentacleTouchSub);
        }

}
