using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public Image image;
    public Color flashColor = Color.blue;
    public float duration = 1f;

    private Color baseColor;
    private float timepass;

    private void Start()
    {
        baseColor = image.color;
    }

    public void Animate()
    {
        enabled = true;
        timepass = 0f;
    }

    void Update()
    {
        timepass += Time.deltaTime;
        if (timepass <= duration / 2f)
        {
            image.color = Color.Lerp(baseColor, flashColor, timepass / (duration / 2f));
        }
        else
        {
            if (timepass > duration)
            {
                timepass = duration;
                enabled = false;
            }

            image.color = Color.Lerp(flashColor, baseColor, timepass / (duration / 2f) - 1f);
        }
    }
}