using UnityEngine;

namespace Sounds
{
    public class GameSpeaker : MonoBehaviour
    {
        public static GameSpeaker current = null;
        public AudioSource SfxAudioSource;
        private void Start()
        {
            if (current != null) {
                Destroy(gameObject);
                return;
            }
            else {
                current = this;
            }
        }
    }
}
