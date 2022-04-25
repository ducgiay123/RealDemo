using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class UISwitch : MonoBehaviour
{
    public GameObject UIObject;
    // Start is called before the first frame update
    public InputHelpers.Button SwitchUIButton;
    public XRController rightHand;
    //private InputDevice targetDevice;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputHelpers.IsPressed(rightHand.inputDevice , SwitchUIButton, out bool isActivated) && isActivated){
            UIObject.SetActive(true);
        }
        else{
            UIObject.SetActive(false);
        }
    }
    // public bool CheckIfActivated (XRController controller){
    //     InputHelpers.IsPressed(controller.inputDevice , SwitchUIButton, out bool isActivated);
    //     return isActivated;
    // }
}
