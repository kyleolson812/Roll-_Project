 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class MovementTest    : MonoBehaviour {
 
     public float Accellaration = 100;
     public float maxSpeed = 2;
     public float JumpHeight = 3;
 
     public float MouseSpeed = 3;
     public GameObject Camera; // you need to set this to the camera you want to use
     public float Zoffset= 90;
 
     private float LookAngleX = 0;
     private float LookAngleY = 0;
 
     private Rigidbody rb;
     private Vector3 movement;
     private Vector2 XYmovement;
     private  float Jump;
 
     void Start () {
         rb = gameObject.GetComponent<Rigidbody>();
     }
 
     void FixedUpdate (){
 
         //###################### Movement ###############################
         float moveVert = Input.GetAxis ("Vertical");
         float moveHor = Input.GetAxis ("Horizontal");
 
         XYmovement = new Vector2 (rb.velocity.x, rb.velocity.z);
 
         if( XYmovement.magnitude > maxSpeed)// clamping speed to max speed
         {
             XYmovement = XYmovement.normalized * maxSpeed;
             rb.velocity = new Vector3 (XYmovement.x, rb.velocity.y, XYmovement.y);
         }
 
         if (Input.GetButtonDown ("Jump")) {
             Jump = JumpHeight;
         }
 
         movement = new Vector3 (moveVert, Jump, -moveHor);
         movement = transform.TransformDirection (movement);
 
         rb.AddForce (movement*Accellaration);
 
 
         //##################### Mouse Controll ##########################
         // Taking controller mouse input
         var Xin = Input.GetAxis ("Mouse X");
         var Yin = Input.GetAxis ("Mouse Y");
 
         LookAngleX += Xin * MouseSpeed;
         LookAngleY += Yin * MouseSpeed;
 
         LookAngleY = Mathf.Clamp (LookAngleY, -70f, 89f);
 
         Camera.transform.localEulerAngles = new Vector3(-LookAngleY, Zoffset, 0f);
         transform.eulerAngles = new Vector3(0f, LookAngleX, 0f);
 
         Jump = 0f;
 
     }
 }