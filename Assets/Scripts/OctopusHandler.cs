using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHandler : MonoBehaviour {
        //触手松开与连接的事件声明
        private Subscription<TentacleLoose> TentacleLooseSub;
        private Subscription<TentacleTouch> TentacleTouchSub;
        //触手列表
        public List<Transform> tentacleList;

        void Start() {
                TentacleLooseSub = EventBus.Subscribe<TentacleLoose>(TentacleLooseFunc);
        }

        private void TentacleLooseFunc(TentacleLoose tentacleLoose) {

        }



}
