using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas canvas;

    public void ShowCanvas()
    {
        canvas.enabled = true;
    }

    public void HideCanvas()
    {
        canvas.enabled = false;
    }

    public void ToggleCanvasVisibility()
    {
        canvas.enabled = !canvas.enabled;
    }
}
