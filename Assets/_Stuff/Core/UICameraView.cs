using UnityEngine;

namespace IpegamaGames
{
    public class UICameraView : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}