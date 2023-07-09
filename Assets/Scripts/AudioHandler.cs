using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
        //播放音效事件声明
        private Subscription<PlayAudioClip> PlayAudioClipSub;
        //播放BGM事件声明
        private Subscription<PlayBGM> PlayBGMSub;
        //停止BGM事件声明
        private Subscription<StopBGM> StopBGMSub;

        public List<Transform> audioClipList;

        public Transform bgmSourceTransform;

        void Start() {
                PlayAudioClipSub = EventBus.Subscribe<PlayAudioClip>(PlayAudioClipFunc);
                PlayBGMSub = EventBus.Subscribe<PlayBGM>(PlayBGMFunc);
                StopBGMSub = EventBus.Subscribe<StopBGM>(StopBGMFunc);
        }

        void PlayAudioClipFunc(PlayAudioClip playAudioClip) {
                audioClipList[playAudioClip.clipIndex].GetComponent<AudioSource>().Play();
        }

        void PlayBGMFunc(PlayBGM playBGM) {
                bgmSourceTransform.GetComponent<AudioSource>().Play();
        }

        void StopBGMFunc(StopBGM stopBGM) {
                bgmSourceTransform.GetComponent<AudioSource>().Pause();
        }

        void OnDestroy() {
                EventBus.Unsubscribe(PlayAudioClipSub);
        }
}
