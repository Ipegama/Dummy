#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class MapEditorWindow : EditorWindow
{
    private MapData mapData;
    private int gridHalfSize = 5; // zakres -5 .. 5
    private float buttonSize = 40f;

    private enum TileState { Empty, Locked, Unlocked }
    private TileState selectedState = TileState.Unlocked;

    private EnemyData enemyToAssign; // wybrany przeciwnik

    [MenuItem("Window/Map Editor")]
    public static void ShowWindow()
    {
        GetWindow<MapEditorWindow>("Map Editor");
    }

    private void OnGUI()
    {
        mapData = (MapData)EditorGUILayout.ObjectField("Map Data", mapData, typeof(MapData), false);

        if (mapData == null) return;

        GUILayout.Space(10);

        // wybór stanu tile
        selectedState = (TileState)EditorGUILayout.EnumPopup("Tile Mode", selectedState);

        // wybór przeciwnika
        enemyToAssign = (EnemyData)EditorGUILayout.ObjectField("Enemy", enemyToAssign, typeof(EnemyData), false);

        GUILayout.Space(10);

        for (int y = gridHalfSize; y >= -gridHalfSize; y--)
        {
            GUILayout.BeginHorizontal();
            for (int x = -gridHalfSize; x <= gridHalfSize; x++)
            {
                Vector2 pos = new Vector2(x, y);
                TileData tile = mapData.tiles.Find(t => t.position == pos);

                // 🔹 kolor przycisku zależny od unlock state
                if (tile == null) GUI.color = Color.gray; // empty
                else GUI.color = tile.isInitiallyUnlocked ? Color.green : Color.red;

                string label = "";
                if (tile != null)
                {
                    label = tile.enemyData != null ? "M" : "E";
                }

                if (GUILayout.Button(label, GUILayout.Width(buttonSize), GUILayout.Height(buttonSize)))
                {
                    ApplyTileState(pos, tile);
                }
            }
            GUILayout.EndHorizontal();
        }

        GUI.color = Color.white;
    }

    private void ApplyTileState(Vector2 pos, TileData tile)
    {
        switch (selectedState)
        {
            case TileState.Empty:
                if (tile != null)
                {
                    mapData.tiles.Remove(tile);
                    EditorUtility.SetDirty(mapData);
                }
                break;

            case TileState.Locked:
                if (tile == null)
                {
                    tile = new TileData { position = pos, isInitiallyUnlocked = false, enemyData = enemyToAssign };
                    mapData.tiles.Add(tile);
                }
                else
                {
                    tile.isInitiallyUnlocked = false;
                    tile.enemyData = enemyToAssign;
                }
                EditorUtility.SetDirty(mapData);
                break;

            case TileState.Unlocked:
                if (tile == null)
                {
                    tile = new TileData { position = pos, isInitiallyUnlocked = true, enemyData = enemyToAssign };
                    mapData.tiles.Add(tile);
                }
                else
                {
                    tile.isInitiallyUnlocked = true;
                    tile.enemyData = enemyToAssign;
                }
                EditorUtility.SetDirty(mapData);
                break;
        }
    }
}
#endif
