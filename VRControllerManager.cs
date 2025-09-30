using UnityEngine;
using UnityEngine.XR;

public class BaggageMeasurement : MonoBehaviour
{
    [Header("Measurement Settings")]
    public Vector3 maxAllowedSize = new Vector3(0.56f, 0.36f, 0.23f); // in meters
    public float tolerance = 0.02f; // 2cm tolerance
    
    [Header("References")]
    public Transform measurementBox;
    public Material validMaterial;
    public Material invalidMaterial;
    public AudioClip successSound;
    public AudioClip failSound;
    
    private Vector3 baggageSize;
    private bool isMeasuring = false;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateMeasurementBoxVisual();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Baggage"))
        {
            StartMeasurement(other.gameObject);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Baggage"))
        {
            StopMeasurement();
        }
    }
    
    void StartMeasurement(GameObject baggage)
    {
        isMeasuring = true;
        CalculateBaggageSize(baggage);
        CheckSizeValidity();
    }
    
    void CalculateBaggageSize(GameObject baggage)
    {
        Renderer renderer = baggage.GetComponent<Renderer>();
        if (renderer != null)
        {
            baggageSize = renderer.bounds.size;
        }
        else
        {
            // Fallback: use collider bounds
            Collider collider = baggage.GetComponent<Collider>();
            if (collider != null)
            {
                baggageSize = collider.bounds.size;
            }
        }
    }
    
    void CheckSizeValidity()
    {
        bool isValid = IsSizeValid();
        
        // Update visual feedback
        MeshRenderer boxRenderer = measurementBox.GetComponent<MeshRenderer>();
        boxRenderer.material = isValid ? validMaterial : invalidMaterial;
        
        // Play sound
        if (audioSource != null)
        {
            audioSource.clip = isValid ? successSound : failSound;
            audioSource.Play();
        }
        
        // Show result in console (replace with your UI)
        Debug.Log($"Baggage Size: {baggageSize.x * 100:F1}cm x {baggageSize.y * 100:F1}cm x {baggageSize.z * 100:F1}cm");
        Debug.Log(isValid ? "PASS - Hand Carry Allowed" : "FAIL - Must Check In");
    }
    
    bool IsSizeValid()
    {
        return baggageSize.x <= maxAllowedSize.x + tolerance &&
               baggageSize.y <= maxAllowedSize.y + tolerance &&
               baggageSize.z <= maxAllowedSize.z + tolerance;
    }
    
    void UpdateMeasurementBoxVisual()
    {
        if (measurementBox != null)
        {
            measurementBox.localScale = maxAllowedSize;
        }
    }
    
    void StopMeasurement()
    {
        isMeasuring = false;
    }
}
