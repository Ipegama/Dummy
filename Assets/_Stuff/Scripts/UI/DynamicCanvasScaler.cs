using UnityEngine;
using UnityEngine.UI;

public class DynamicCanvasScaler : MonoBehaviour
{
    [SerializeField] private CanvasScaler scaler;

    [ContextMenu("Set Reference To Current Screen Size")]
    public void SetReferenceResolution()
    {
        if (scaler != null)
        {
            scaler.referenceResolution = new Vector2(Screen.width,Screen.height);
            Debug.Log($"Reference Resolution set to: {Screen.width} x {Screen.height}");
        }
    }
}
