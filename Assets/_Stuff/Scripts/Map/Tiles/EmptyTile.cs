using UnityEngine;

namespace IpegamaGames
{
    public class EmptyTile : Tile
    {
        public override bool Interact(Transform playerTransform)
        {
            //playerTransform.position = new Vector3(Position.x, Position.y, playerTransform.position.z);
            return true;
        }
    }
}