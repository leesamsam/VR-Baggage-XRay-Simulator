public class GrabableLuggage : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }
    
    void OnGrabbed(XRBaseInteractor interactor)
    {
        // Handle when object is grabbed
        rb.isKinematic = true;
    }
    
    void OnReleased(XRBaseInteractor interactor)
    {
        // Handle when object is released
        rb.isKinematic = false;
    }
}
