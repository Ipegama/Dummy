using UnityEngine;

namespace IpegamaGames
{
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