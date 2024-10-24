using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementData : MonoBehaviour
{
    private string elementName;
    public string ElementName { get { return elementName; } }
    private string elementSymbol;
    public string ElementSymbol { get { return elementSymbol; } }
    private int atomicNumber;
    public int AtomicNumber { get { return atomicNumber; } }
    private float averageAtomicMass;
    public float AverageAtomicMass { get { return averageAtomicMass; } }
    private string elementCategory;
    public string ElementCategory { get { return elementCategory; } }
    private string elementState;
    public string ElementState { get { return elementState; } }
    private string elementDensity;
    public string ElementDensity { get { return elementDensity; } }
    private string meltingPoint;
    public string MeltingPoint { get { return meltingPoint; } }
    private string boilingPoint;
    public string BoilingPoint { get { return boilingPoint; } }
    private int neutronCount;
    public int NeutronCount {get { return neutronCount; }}
    private int protonCount;
    public int ProtonCount { get { return protonCount; } }
    private int electronCount;
    public int ElectronCount { get { return electronCount; } }
    private int electronShells;
    public int ElectronShells { get { return electronShells; } }
    private int[] electronsPerShell;
    public int[] ElectronsPerShell { get { return electronsPerShell; } }

    public TextMeshPro textElementName;
    public TextMeshPro textElementSymbol;
    public TextMeshPro textAtomicNumber;
    public TextMeshPro textAverageAtomicMass;
    public Renderer elementRenderer;
    
    public void SetElementData(string name, string symbol, int number, float mass, string category, string state, string density, string melting, string boiling)
    {
        elementName = name;
        elementSymbol = symbol;
        atomicNumber = number;
        averageAtomicMass = mass;
        elementCategory = category;
        elementState = state;
        elementDensity = density;
        meltingPoint = melting;
        boilingPoint = boiling;

        textElementName.text = elementName;
        textElementSymbol.text = elementSymbol;
        textAtomicNumber.text = atomicNumber.ToString();
        textAverageAtomicMass.text = averageAtomicMass.ToString();
    }

    public void SetElementMaterial(string category)
    {
        switch(category)
        {
            case "Alkali metal":
                elementRenderer.material = Resources.Load<Material>("Materials/AlkaliMetal");
                break;
            case "Alkaline-earth metal":
                elementRenderer.material = Resources.Load<Material>("Materials/AlkalineEarthMetal");
                break;
            case "Transition metal":
                elementRenderer.material = Resources.Load<Material>("Materials/TransitionMetal");
                break;
            case "Post-transition metal":
                elementRenderer.material = Resources.Load<Material>("Materials/PostTransitionMetal");
                break;
            case "Metalloid":
                elementRenderer.material = Resources.Load<Material>("Materials/Metalloid");
                break;
            case "Nonmetal":
                elementRenderer.material = Resources.Load<Material>("Materials/Nonmetal");
                break;
            case "Halogen":
                elementRenderer.material = Resources.Load<Material>("Materials/Halogen");
                break;
            case "Noble gas":
                elementRenderer.material = Resources.Load<Material>("Materials/NobleGas");
                break;
            case "Lanthanide":
                elementRenderer.material = Resources.Load<Material>("Materials/Lanthanide");
                break;
            case "Actinide":
                elementRenderer.material = Resources.Load<Material>("Materials/Actinide");
                break;
            default:
                elementRenderer.material = Resources.Load<Material>("Materials/Default");
                break;
        }
    }
}
