using TMPro;
using UnityEngine;

public class ElementInfoDisplay : MonoBehaviour
{
    private ElementData elementData;
    private TextMeshProUGUI textElementName;
    private TextMeshProUGUI textElementSymbol;
    private TextMeshProUGUI textAtomicNumber;
    private TextMeshProUGUI textAverageAtomicMass;
    private TextMeshProUGUI textElementCategory;
    private TextMeshProUGUI textElementState;
    private TextMeshProUGUI textElementDensity;
    private TextMeshProUGUI textMeltingPoint;
    private TextMeshProUGUI textBoilingPoint;
    private GameObject informationDisplay;
    private GameObject informationCanvas;
    private AudioSource clickAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        clickAudioSource = GetComponent<AudioSource>();
        if (clickAudioSource == null)
        {
            Debug.LogError("Audio Source not found.");
        }
        elementData = GetComponent<ElementData>();
        if (elementData == null)
        {
            Debug.LogError("ElementData component not found.");
        }
        informationDisplay = GameObject.FindWithTag("InformationDisplay");
        if (informationDisplay == null)
        {
            Debug.LogError("Information Display not found.");
        }
        informationCanvas = GameObject.FindWithTag("InformationCanvas");
        if (informationCanvas == null)
        {
            Debug.LogError("Information Canvas not found.");
        }
        textElementName = informationCanvas.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        textElementSymbol = informationCanvas.transform.Find("SymbolText").GetComponent<TextMeshProUGUI>();
        textAtomicNumber = informationCanvas.transform.Find("AtomicNumberText").GetComponent<TextMeshProUGUI>();
        textAverageAtomicMass = informationCanvas.transform.Find("AtomicMassText").GetComponent<TextMeshProUGUI>();
        textElementCategory = informationCanvas.transform.Find("CategoryText").GetComponent<TextMeshProUGUI>();
        textElementState = informationCanvas.transform.Find("StateText").GetComponent<TextMeshProUGUI>();
        textElementDensity = informationCanvas.transform.Find("DensityText").GetComponent<TextMeshProUGUI>();
        textMeltingPoint = informationCanvas.transform.Find("MeltingPointText").GetComponent<TextMeshProUGUI>();
        textBoilingPoint = informationCanvas.transform.Find("BoilingPointText").GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        SetElementInfo();
        SetDisplayMaterial();
        PlayClickSound();
    }

    private void SetElementInfo()
    {
        textElementName.text = elementData.ElementName;
        textElementSymbol.text = "Symbol: " + elementData.ElementSymbol;
        textAtomicNumber.text = "Atomic Number: " + elementData.AtomicNumber.ToString();
        textAverageAtomicMass.text = "Avg. Atomic Mass: " + elementData.AverageAtomicMass.ToString();
        textElementCategory.text = "Category: " + elementData.ElementCategory;
        textElementState.text = "State: " + elementData.ElementState;
        textElementDensity.text = "Density: " + elementData.ElementDensity;
        textMeltingPoint.text = "Melting Point: " + elementData.MeltingPoint;
        textBoilingPoint.text = "Boiling Point: " + elementData.BoilingPoint;
    }

    private void SetDisplayMaterial()
    {
        elementData.SetElementMaterial(elementData.ElementCategory);
        informationDisplay.GetComponent<Renderer>().material = elementData.elementRenderer.material;
    }

    private void PlayClickSound()
    {
        clickAudioSource.Play();
    }
}
