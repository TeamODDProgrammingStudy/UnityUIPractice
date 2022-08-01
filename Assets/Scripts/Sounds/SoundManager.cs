using UnityEngine;

namespace Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public void PlaySfxSound(AudioClip audioClip)
        {
            if (GameSpeaker.current){
                GameSpeaker.current.SfxAudioSource.PlayOneShot(audioClip);
            }
        }
    }
}
