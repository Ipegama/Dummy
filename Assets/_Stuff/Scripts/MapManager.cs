using System.Collections.Generic;
using UnityEngine;

namespace IpegamaGames
{
    public class MapManager : Singleton<MapManager>
    {
        [SerializeField] private Tile tilePrefab;
        public Dictionary<Vector2Int, Tile> TileMap { get; private set;} = new Dictionary<Vector2Int, Tile>();

        private void Start()
        {
            //TileMap.Add(new Vector2Int(0, 0), new Tile());
            CreateMap(new List<Vector2Int>
            {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                new Vector2Int(0, 3),
                new Vector2Int(1, 3),
            });
        }
        public void CreateMap(List<Vector2Int> tilesPos)
        {
            foreach (var tilePos in tilesPos)
            {
                Tile newTile = Instantiate(tilePrefab, new Vector3(tilePos.x,tilePos.y,0),Quaternion.identity);
                TileMap.Add(tilePos,newTile);
            }
        }
        public bool CanMoveTo(Vector2Int dir, Transform transform)
        {
            Vector2Int currentPos = Vector2Int.RoundToInt(transform.position);
            Vector2Int targetPos = currentPos + dir;

            return TileMap.ContainsKey(targetPos);
        }
    }
}