using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocoController : MonoBehaviour
{
    // Start is called before the first frame update
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActionButton;
    public float activationThreshold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(leftTeleportRay){
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }
        if(rightTeleportRay){
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
        }
    }
    public bool CheckIfActivated (XRController controller){
        InputHelpers.IsPressed(controller.inputDevice , teleportActionButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}
