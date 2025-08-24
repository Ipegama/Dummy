#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CardEditorWindow : EditorWindow
{
    private CardData selectedCardData;

    [MenuItem("Window/Card Editor")]
    public static void ShowWindow()
    {
        GetWindow<CardEditorWindow>("Card Editor");
    }

    private void OnGUI()
    {
        // wybór assetu karty
        selectedCardData = (CardData)EditorGUILayout.ObjectField("Card Data", selectedCardData, typeof(CardData), false);

        if (selectedCardData == null)
        {
            EditorGUILayout.HelpBox("Wybierz asset typu CardData, aby rozpocząć edycję.", MessageType.Info);
            return;
        }

        GUILayout.Space(10);

        // 🔹 Edycja pól CardData
        EditorGUI.BeginChangeCheck();

        selectedCardData.cardName = EditorGUILayout.TextField("Name", selectedCardData.cardName);
        selectedCardData.cardDescription = EditorGUILayout.TextField("Description", selectedCardData.cardDescription);
        selectedCardData.cardIcon = (Sprite)EditorGUILayout.ObjectField("Icon", selectedCardData.cardIcon, typeof(Sprite), false);
        selectedCardData.cardPrefab = (Card)EditorGUILayout.ObjectField("Prefab", selectedCardData.cardPrefab, typeof(Card), false);

        // 🔹 lista efektów (SerializedObject dla List<T>)
        SerializedObject so = new SerializedObject(selectedCardData);
        SerializedProperty effectsProp = so.FindProperty("effects");
        EditorGUILayout.PropertyField(effectsProp, true);
        so.ApplyModifiedProperties();

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(selectedCardData);
        }

        GUILayout.Space(20);
        GUILayout.Label("Card Preview", EditorStyles.boldLabel);

        DrawCardPreview(selectedCardData);
    }

    private void DrawCardPreview(CardData data)
    {
        // rozmiar karty
        Rect rect = GUILayoutUtility.GetRect(150, 200, GUILayout.ExpandWidth(false));
        GUI.Box(rect, GUIContent.none);

        // tło karty
        EditorGUI.DrawRect(rect, new Color(0.95f, 0.9f, 0.8f)); // jasny beż

        // 🔹 nazwa (niebieski pasek trochę niżej)
        Rect nameRect = new Rect(rect.x, rect.y + 5, rect.width, 20);
        EditorGUI.DrawRect(nameRect, new Color(0.2f, 0.4f, 0.7f)); // niebieski pasek
        GUIStyle nameStyle = new GUIStyle(EditorStyles.boldLabel)
        {
            alignment = TextAnchor.MiddleCenter,
            normal = { textColor = Color.white }
        };
        EditorGUI.LabelField(nameRect, string.IsNullOrEmpty(data.cardName) ? "Card Name" : data.cardName, nameStyle);

        // ikonka w środku
        if (data.cardIcon != null)
        {
            Rect iconRect = new Rect(rect.x + rect.width * 0.2f, rect.y + 30, rect.width * 0.6f, rect.width * 0.6f);
            EditorGUI.DrawPreviewTexture(iconRect, data.cardIcon.texture, null, ScaleMode.ScaleToFit);
        }
        else
        {
            Rect iconRect = new Rect(rect.x + rect.width * 0.2f, rect.y + 30, rect.width * 0.6f, rect.width * 0.6f);
            EditorGUI.DrawRect(iconRect, new Color(0.7f, 0.7f, 0.7f));
            GUIStyle placeholderStyle = new GUIStyle(EditorStyles.label)
            {
                alignment = TextAnchor.MiddleCenter,
                normal = { textColor = Color.black }
            };
            EditorGUI.LabelField(iconRect, "No Icon", placeholderStyle);
        }

        // 🔹 opis (czarny tekst)
        Rect descRect = new Rect(rect.x + 5, rect.yMax - 45, rect.width - 10, 40);
        GUIStyle wrapStyle = new GUIStyle(EditorStyles.wordWrappedLabel)
        {
            alignment = TextAnchor.UpperCenter,
            fontSize = 10,
            normal = { textColor = Color.black } // <- czarny tekst
        };
        EditorGUI.LabelField(descRect, string.IsNullOrEmpty(data.cardDescription) ? "Card description..." : data.cardDescription, wrapStyle);
    }

}
#endif
