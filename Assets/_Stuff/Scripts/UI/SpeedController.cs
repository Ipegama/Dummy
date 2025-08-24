using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [SerializeField] private float fastSpeed = 3f;
    [SerializeField] private float normalSpeed = 1f;

    private bool isFast = false;

    public void ToggleSpeed()
    {
        isFast = !isFast;
        Time.timeScale = isFast ? fastSpeed : normalSpeed;
    }

    private void OnDisable()
    {
        Time.timeScale = normalSpeed;
        isFast = false;
    }
}
