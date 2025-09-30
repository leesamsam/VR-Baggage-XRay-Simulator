using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableBaggage : XRGrabInteractable
{
    [Header("Baggage Settings")]
    public BaggageType type = BaggageType.CarryOn;
    
    void Start()
    {
        // Configure grab interactions
        onSelectEntered.AddListener(OnGrabbed);
        onSelectExited.AddListener(OnReleased);
    }
    
    void OnGrabbed(XRBaseInteractor interactor)
    {
        // Visual feedback when grabbed
        GetComponent<Rigidbody>().isKinematic = false;
    }
    
    void OnReleased(XRBaseInteractor interactor)
    {
        // Reset physics
        GetComponent<Rigidbody>().isKinematic = false;
    }
    
    protected override void OnDestroy()
    {
        onSelectEntered.RemoveListener(OnGrabbed);
        onSelectExited.RemoveListener(OnReleased);
        base.OnDestroy();
    }
}

public enum BaggageType
{
    CarryOn,
    CheckIn
}
