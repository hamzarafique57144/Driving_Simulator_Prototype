using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 20000f;
    private float turnSpeed=20f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    [SerializeField] private GameObject centerOfMass;
    [SerializeField]  TextMeshProUGUI  speedoMeterTxt ;
    [SerializeField] float speed;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedoMeterTxt.text = speed.ToString()+" Km/h";
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //   transform.Translate(Vector3.forward*speed*Time.deltaTime*verticalInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        transform.Rotate(Vector3.up * turnSpeed*Time.deltaTime*horizontalInput);
    }
    
        

    

    
    
}
