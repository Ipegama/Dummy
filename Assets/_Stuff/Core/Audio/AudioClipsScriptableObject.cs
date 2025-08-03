using UnityEngine;

namespace IpegamaGames
{
    public abstract class AudioClipsScriptableObject : ScriptableObject
    {
        public SerializableDictionary<AudioClipType, AudioClip> AudioClips;
    }
}
