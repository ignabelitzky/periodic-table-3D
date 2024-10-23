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
    public GameObject elementInformationCanvas;
    // Start is called before the first frame update
    void Start()
    {
        elementData = GetComponent<ElementData>();
        if (elementData == null)
        {
            Debug.LogError("ElementData component not found.");
        }
        elementInformationCanvas = GameObject.FindWithTag("InformationDisplay");
        if (elementInformationCanvas == null)
        {
            Debug.LogError("Canvas not found.");
        }
        textElementName = elementInformationCanvas.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        textElementSymbol = elementInformationCanvas.transform.Find("SymbolText").GetComponent<TextMeshProUGUI>();
        textAtomicNumber = elementInformationCanvas.transform.Find("AtomicNumberText").GetComponent<TextMeshProUGUI>();
        textAverageAtomicMass = elementInformationCanvas.transform.Find("AtomicMassText").GetComponent<TextMeshProUGUI>();
        textElementCategory = elementInformationCanvas.transform.Find("CategoryText").GetComponent<TextMeshProUGUI>();
        textElementState = elementInformationCanvas.transform.Find("StateText").GetComponent<TextMeshProUGUI>();
        textElementDensity = elementInformationCanvas.transform.Find("DensityText").GetComponent<TextMeshProUGUI>();
        textMeltingPoint = elementInformationCanvas.transform.Find("MeltingPointText").GetComponent<TextMeshProUGUI>();
        textBoilingPoint = elementInformationCanvas.transform.Find("BoilingPointText").GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        SetElementInfo();
    }

    private void SetElementInfo()
    {
        textElementName.text = elementData.ElementName;
        textElementSymbol.text = "Symbol >> " + elementData.ElementSymbol;
        textAtomicNumber.text = "Atomic Number >> " + elementData.AtomicNumber.ToString();
        textAverageAtomicMass.text = "Avg. Atomic Mass >> " + elementData.AverageAtomicMass.ToString();
        textElementCategory.text = "Category >> " + elementData.ElementCategory;
        textElementState.text = "State >> " + elementData.ElementState;
        textElementDensity.text = "Density >> " + elementData.ElementDensity;
        textMeltingPoint.text = "Melting Point >> " + elementData.MeltingPoint;
        textBoilingPoint.text = "Boiling Point >> " + elementData.BoilingPoint;
    }
}
