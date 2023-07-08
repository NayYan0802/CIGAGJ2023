using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

        [Range(0, 5)]
        public int tentacleIndex;
        public Vector3 targetPosition;
        void OnMouseDown() {
                EventBus.Publish(new TentacleLoose(tentacleIndex));
        }
        //void OnMouseUpAsButton() {
        //        EventBus.Publish(new TentacleTouch(tentacleIndex, targetPosition));
        //}
}