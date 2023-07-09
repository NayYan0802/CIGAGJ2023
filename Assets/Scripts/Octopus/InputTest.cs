using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

        [Range(0, 5)]
        public int tentacleIndex;

        [Range(0, 6)]
        public int audioClipIndex;

        public Vector3 targetPosition;
        void OnMouseDown() {
                EventBus.Publish(new TentacleLoose(tentacleIndex));
                //EventBus.Publish(new PlayBGM());
                EventBus.Publish(new PlayAudioClip(1));
        }
        void OnMouseUpAsButton() {
                EventBus.Publish(new TentacleTouch(tentacleIndex, targetPosition));
                //EventBus.Publish(new StopBGM());
                EventBus.Publish(new PlayAudioClip(0));
        }
}