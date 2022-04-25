using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class spinitself : MonoBehaviour
{
    public InputHelpers.Button SpinButton;
    public XRController rightHand;
    public float spinSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputHelpers.IsPressed(rightHand.inputDevice , SpinButton, out bool isActivated)&& isActivated){
            transform.Rotate(0f , 0f , spinSpeed * Time.deltaTime , Space.Self);
        }
    }
}
