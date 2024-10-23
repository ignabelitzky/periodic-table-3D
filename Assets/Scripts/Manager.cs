using System.Collections;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public TextAsset elementsData;
    public GameObject elementPrefab;
    public ElementInfoList elements = new ElementInfoList();

    [System.Serializable]
    public class ElementInfo
    {
        public string Name;
        public string Symbol;
        public int AtomicNumber;
        public float AverageAtomicMass;
        public string Type;
        public string State;
        public string Density;
        public string MeltingPoint;
        public string BoilingPoint;
        public int NeutronCount;
        public int ProtonCount;
        public int ElectronCount;
        public int ElectronShells;
        public int[] ElectronsPerShell;
        public float xPos;
        public float yPos;
    }

    [System.Serializable]
    public class ElementInfoList
    {
        public ElementInfo[] elements;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadElements();
        CreateElements();
    }

    void LoadElements()
    {
        if (elementsData == null)
        {
            Debug.LogWarning("Elements data not found.");
            return;
        }
        elements = JsonUtility.FromJson<ElementInfoList>(elementsData.text);
        if (elements.elements == null || elements.elements.Length == 0)
        {
            Debug.LogError("No elements found in the data.");
        }
    }

    void CreateElements()
    {
        foreach (ElementInfo element in elements.elements)
        {
            GameObject newElement = Instantiate(elementPrefab, new Vector3(element.xPos, element.yPos, 0), Quaternion.identity);
            newElement.name = element.Name;
            ElementData elementData = newElement.GetComponent<ElementData>();

            if (elementData == null)
            {
                Debug.LogWarning("ElementData component not found.");
                return;
            }
            elementData.SetElementData(element.Name, element.Symbol, element.AtomicNumber, element.AverageAtomicMass, element.Type, element.State, element.Density, element.MeltingPoint, element.BoilingPoint);
            elementData.SetElementMaterial(element.Type);
        }
    }
}
