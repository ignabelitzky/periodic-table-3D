using System.Collections;
using UnityEngine;

public class ElementHover : MonoBehaviour
{
    private float scaleFactor = 1.2f;
    private Vector3 originalScale;
    private Material hoverMaterial;
    private Material defaultMaterial;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        defaultMaterial = GetComponent<Renderer>().material;
        hoverMaterial = Resources.Load<Material>("Materials/HoverMaterial");
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material = hoverMaterial;
        StartCoroutine(ScaleObject(originalScale * scaleFactor, 0.2f));
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = defaultMaterial;
        StartCoroutine(ScaleObject(originalScale, 0.2f));
    }

    private IEnumerator ScaleObject(Vector3 targetScale, float duration)
    {
        Vector3 originalScale = transform.localScale;
        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= duration);

        transform.localScale = targetScale;
    }
}
