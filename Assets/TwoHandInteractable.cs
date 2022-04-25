using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
public class TwoHandInteractable : XRGrabInteractable
{
    // Start is called before the first frame update
    public List<XRSimpleInteractable> secondhandGrabPoints = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion attachInitialRotation;
    void Start()
    {
        foreach(var item in secondhandGrabPoints){
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(secondInteractor && selectingInteractor){
            selectingInteractor.attachTransform.rotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - 
            selectingInteractor.attachTransform.position);
        }
        base.ProcessInteractable(updatePhase);
    }
    public void OnSecondHandGrab(XRBaseInteractor interactor){
        Debug.Log("Grab");
        secondInteractor = interactor;

    }
    public void OnSecondHandRelease(XRBaseInteractor interactor){
        Debug.Log("Release");
        secondInteractor = null;
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        Debug.Log("Entering");
        base.OnSelectEntering(interactor);
        attachInitialRotation = interactor.attachTransform.localRotation;
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        Debug.Log("Exiting");
        base.OnSelectExiting(interactor);
        secondInteractor = null;
        interactor.attachTransform.localRotation = attachInitialRotation;
    }
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }
}
