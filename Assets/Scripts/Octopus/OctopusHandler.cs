using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusHandler : MonoBehaviour {
        //触手松开与连接的事件声明
        private Subscription<TentacleLoose> TentacleLooseSub;
        private Subscription<TentacleTouch> TentacleTouchSub;

        public List<Transform> tentacleList;

        void Start() {
                TentacleLooseSub = EventBus.Subscribe<TentacleLoose>(TentacleLooseFunc);
                TentacleTouchSub = EventBus.Subscribe<TentacleTouch>(TentacleTouchFunc);
        }

        //触手松开事件执行的方法
        void TentacleLooseFunc(TentacleLoose tentacleLoose) {
                tentacleList[tentacleLoose.tentacleIndex].GetComponent<Tentacle>().SetAnimation(true);
        }
        //触手连接事件执行的方法
        void TentacleTouchFunc(TentacleTouch tentacleTouch) {
                //tentacleList[tentacleTouch.tentacleIndex].GetComponent<Tentacle>().MoveTentacle(tentacleTouch.targetPos);
                tentacleList[tentacleTouch.tentacleIndex].GetComponent<Tentacle>().SetAnimation(false);
        }



        //事件释放的缓存
        void OnDestroy() {
                EventBus.Unsubscribe(TentacleLooseSub);
                EventBus.Unsubscribe(TentacleTouchSub);
        }

}
