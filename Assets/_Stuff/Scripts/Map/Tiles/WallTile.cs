using UnityEngine;

namespace IpegamaGames
{
    public class WallTile : Tile
    {
        public override bool Interact(Transform playerTransform)
        {
            Debug.Log("To jest ściana, nie możesz tam wejść.");
            // Możesz tu wywołać UI lub dźwięk
            return false; // ruch zablokowany
        }
    }
}