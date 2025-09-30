public class XRayScanner : MonoBehaviour
{
    public RenderTexture xRayRenderTexture;
    public Camera xRayCamera;
    public Material xRayMaterial;
    
    void OnTriggerEnter(Collider other)
    {
        Luggage luggage = other.GetComponent<Luggage>();
        if (luggage != null)
        {
            StartCoroutine(ScanLuggage(luggage));
        }
    }
    
    IEnumerator ScanLuggage(Luggage luggage)
    {
        // Show scanning UI
        ShowScanningUI();
        
        // Perform X-ray scan
        luggage.ShowXRayView(true);
        xRayCamera.Render();
        
        yield return new WaitForSeconds(2f);
        
        // Display scan results
        DisplayScanResult(luggage);
        luggage.ShowXRayView(false);
    }
    
    void ShowScanningUI()
    {
        // Display scanning progress UI
    }
    
    void DisplayScanResult(Luggage luggage)
    {
        // Show scan results on security monitor
    }
}
