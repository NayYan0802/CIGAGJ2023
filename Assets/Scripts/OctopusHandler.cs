using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHandler : MonoBehaviour {
        //�����ɿ������ӵ��¼�����
        private Subscription<TentacleLoose> TentacleLooseSub;
        private Subscription<TentacleTouch> TentacleTouchSub;
        //�����б�
        public List<Transform> tentacleList;

        void Start() {
                TentacleLooseSub = EventBus.Subscribe<TentacleLoose>(TentacleLooseFunc);
        }

        private void TentacleLooseFunc(TentacleLoose tentacleLoose) {

        }



}
