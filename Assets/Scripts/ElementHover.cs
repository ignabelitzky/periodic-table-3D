using System.Collections;
using UnityEngine;

public class ElementHover : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private float scaleDuration = 0.2f;
    private Vector3 originalScale;
    private Material hoverMaterial;
    private Material defaultMaterial;
    private Renderer objectRenderer;
    private MaterialPropertyBlock propertyBlock;
    // Start is called before the first frame update
    void Start()
    {
        // Cache the original scale and the renderer
        originalScale = transform.localScale;
        objectRenderer = GetComponent<Renderer>();

        // Load materials
        defaultMaterial = objectRenderer.material;
        hoverMaterial = Resources.Load<Material>("Materials/HoverMaterial");

        // Initialize MaterialPropertyBlock
        propertyBlock = new MaterialPropertyBlock();
    }

    private void OnMouseEnter()
    {
        // Change material using MaterialPropertyBlock
        SetMaterial(hoverMaterial);

        // Starting scaling coroutine
        StartCoroutine(ScaleObject(originalScale * scaleFactor, scaleDuration));
    }

    private void OnMouseExit()
    {
        SetMaterial(defaultMaterial);
        StartCoroutine(ScaleObject(originalScale, scaleDuration));
    }

    private IEnumerator ScaleObject(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    private void SetMaterial(Material material)
    {
        objectRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_Color", material.color);
        objectRenderer.SetPropertyBlock(propertyBlock);
    }
}
