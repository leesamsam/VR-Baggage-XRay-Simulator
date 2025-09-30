using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerManager : MonoBehaviour
{
    public XRController leftController;
    public XRController rightController;
    public InputHelpers.Button grabButton;
    
    void Update()
    {
        // Check for grab input
        if (CheckGrabInput(leftController))
            HandleGrab(leftController);
        if (CheckGrabInput(rightController))
            HandleGrab(rightController);
    }
    
    bool CheckGrabInput(XRController controller)
    {
        controller.inputDevice.IsPressed(grabButton, out bool isPressed);
        return isPressed;
    }
    
    void HandleGrab(XRController controller)
    {
        // Handle grab functionality
    }
}
