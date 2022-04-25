using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
public class DrillingHoleScript : MonoBehaviour
{
    [SerializeField] private GameObject _bulletHolePrefab ;
    // Start is called before the first frame update
    //private InputDevice targetDevice;
    public InputHelpers.Button drillButton;
    public XRController rightHand;
    public float SpawnRate = 1F;
     private float timestamp = 0F;
    public float range = 100f;    

    void Update()
    {
        if (InputHelpers.IsPressed(rightHand.inputDevice , drillButton, out bool isActivated)&& isActivated && Time.time > timestamp){
             timestamp = Time.time + SpawnRate;
            Shoot();
        }
    }
    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) , out hit , range)){
            GameObject obj = Instantiate(_bulletHolePrefab, hit.point , Quaternion.LookRotation(hit.normal));
            obj.transform.position += obj.transform.forward / 1000;
        }
    }
}
