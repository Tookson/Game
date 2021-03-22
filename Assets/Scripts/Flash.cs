using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public Image image;
    public Transform moveTarget;
    public Color flashColor = Color.blue;
    public Vector3 targetDelta = new Vector3(0, 2, 0); 
    public float duration = 1f;

    private Color baseColor;
    private Vector3 basePosition;

    private Coroutine[] _animateCoroutines = new Coroutine[2];

    private void Awake()
    {
        baseColor = image.color;
        basePosition = moveTarget.localPosition;
    }

    public void Animate()
    {
        enabled = true;
        int animationNumber = Random.Range(0, 2); // [from, to);
        if (_animateCoroutines[animationNumber] != null)
        {
            StopCoroutine(_animateCoroutines[animationNumber]);
        }

        // ResetStateToDefault();
        _animateCoroutines[animationNumber] = StartCoroutine(GetAnimation(animationNumber));
    }

    private void ResetStateToDefault()
    {   
        image.color = baseColor;
        moveTarget.localPosition = basePosition;
    }

    private IEnumerator GetAnimation(int animationNumber)
    {
        switch (animationNumber)
        {
            case 0: return ChangeColorCoroutine();
            case 1: return MoveCoroutine();
            default: return null;
        }
    }
    
    private IEnumerator ChangeColorCoroutine()
    {
        float timepass = 0f;

        while (timepass <= duration / 2f)
        {
            timepass += Time.deltaTime;
            image.color = Color.Lerp(baseColor, flashColor, timepass / (duration / 2f));
            yield return null;
        }
        
        while (timepass <= duration)
        {
            timepass += Time.deltaTime;
            image.color = Color.Lerp(flashColor, baseColor, timepass / (duration / 2f) - 1f);
            yield return null;
        }
    }
    
    private IEnumerator MoveCoroutine()
    {
        float timepass = 0f;
        while (timepass <= duration / 2f)
        {
            timepass += Time.deltaTime;
            moveTarget.localPosition = Vector3.Lerp(basePosition, targetDelta, timepass / (duration / 2f));
            yield return null;
        }
        
        while (timepass <= duration)
        {
            timepass += Time.deltaTime;
            moveTarget.localPosition = Vector3.Lerp(targetDelta, basePosition, timepass / (duration / 2f) - 1f);
            yield return null;
        }
    }

    /*
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
    */
}