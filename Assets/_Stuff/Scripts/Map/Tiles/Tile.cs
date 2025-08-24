using UnityEngine;

namespace IpegamaGames
{
    public class Tile : MonoBehaviour
    {
        public Vector2Int Position { get; private set; }

        public virtual void Initialize(Vector2Int position)
        {
            Position = position;
        }

        public virtual bool Interact(Transform playerTransform)
        {
            return false;
        }
    }
}