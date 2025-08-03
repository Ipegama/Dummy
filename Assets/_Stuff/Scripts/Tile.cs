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



    public class EmptyTile : Tile
    {
        public override bool Interact(Transform playerTransform)
        {
            //playerTransform.position = new Vector3(Position.x, Position.y, playerTransform.position.z);
            return true;
        }
    }

    public class WallTile : Tile
    {
        public override bool Interact(Transform playerTransform)
        {
            Debug.Log("To jest ściana, nie możesz tam wejść.");
            // Możesz tu wywołać UI lub dźwięk
            return false; // ruch zablokowany
        }
    }

    public class EnemyTile : Tile
    {
        public override bool Interact(Transform playerTransform)
        {
            Debug.Log("Spotkałeś przeciwnika! Otwieram walkę...");
            // Tutaj np. uruchom UI walki
            // Jeśli walka się powiedzie, można potem wywołać ruch (np. przez PlayerMoveCommand)
            return false; // ruch zablokowany dopóki walka się nie zakończy
        }
    }
}