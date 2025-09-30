public class Luggage : MonoBehaviour
{
    public LuggageType type;
    public List<ProhibitedItem> containedItems;
    public bool isScanned = false;
    
    [Header("X-ray Settings")]
    public Material normalMaterial;
    public Material xRayMaterial;
    public Renderer luggageRenderer;
    
    public void ShowXRayView(bool showXRay)
    {
        if (showXRay)
        {
            luggageRenderer.material = xRayMaterial;
            // Show contained items
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            luggageRenderer.material = normalMaterial;
            // Hide contained items
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}

public enum LuggageType
{
    Backpack,
    Suitcase,
    Handbag
}

[System.Serializable]
public class ProhibitedItem
{
    public string itemName;
    public ItemType type;
    public GameObject itemObject;
    public RiskLevel riskLevel;
}

public enum ItemType
{
    Liquid,
    Weapon,
    Electronics,
    Other
}

public enum RiskLevel
{
    Low,
    Medium,
    High
}
