using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour {
        //������Ч�¼�����
        private Subscription<PlayAudioClip> PlayAudioClipSub;
        //����BGM�¼�����
        private Subscription<PlayBGM> PlayBGMSub;
        //ֹͣBGM�¼�����
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
