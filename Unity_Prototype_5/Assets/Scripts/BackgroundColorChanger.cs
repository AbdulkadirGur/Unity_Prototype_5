using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    public Color[] colors; // Renk geçişlerinde kullanılacak renklerin dizisi
    public float transitionDuration = 2f; // Geçiş süresi

    private Camera mainCamera;
    private int currentIndex = 0;
    private Color startColor;
    private Color targetColor;
    private float transitionStartTime;

    void Start()
    {
        mainCamera = Camera.main;
        startColor = mainCamera.backgroundColor;
        targetColor = colors[currentIndex];
        transitionStartTime = Time.time;
    }

    void Update()
    {
        float t = (Time.time - transitionStartTime) / transitionDuration;
        mainCamera.backgroundColor = Color.Lerp(startColor, targetColor, t);

        if (t >= 1.0f) // Eğer geçiş tamamlandıysa
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            startColor = targetColor;
            targetColor = colors[currentIndex];
            transitionStartTime = Time.time;
        }
    }
}