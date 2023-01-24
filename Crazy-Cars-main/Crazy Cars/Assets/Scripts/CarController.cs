using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody theRB;
    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrehngth = 180, gravityForce = 10f, gragOnGround = 3f;
    //public float forwardAccel , reverseAccel , maxSpeed , turnStrehngth , gravityForce , gragOnGround ;
    private float speedInput, turnInput;
    private bool grounded;
    public LayerMask WhatIsGround;
    public float groundRayLenght = 0.5f;
    public Transform groundRayPoint;
    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25;
    public float dragModifieer = 0f;
    //public ParticleSystem[] dustTrial;
    public float maxEmission = 25f;
    private float emmisionRate;

    public float ForwardAccel { get; private set; }
    public float ReverseAccel { get; private set; }
    public float MaxSpeed { get;  set; }
    public int TurnStrehngth { get; private set; }
    public float GravityForce { get; private set; }
    public float GragOnGround { get; private set; }

    public CarController()
    {

    }


    void Start()
    {
        theRB.transform.parent = null;
        //GameController.car = new CarController();
        //coger el coche que se ha seleccionado y asignar los valores

        /*GameController.car.ForwardAccel = 8f;
        GameController.car.ReverseAccel = 4f;
        GameController.car.MaxSpeed = 1000f;
        GameController.car.TurnStrehngth = 180;
        GameController.car.GravityForce = 10f;
        GameController.car.GragOnGround = 3f;*/
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;           
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel;// * 1000f;
        }
        //giro
        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, turnInput * turnStrehngth * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);

        transform.position = theRB.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLenght, WhatIsGround))
        {
            grounded = true;
            Debug.Log("suelo");
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        emmisionRate = 0f;
        if (grounded)
        {
           
            if (hit.collider.CompareTag("Asfalto"))
            {
                dragModifieer = 0;               
            }
            else if (hit.collider.CompareTag("Cesped"))
            {
                dragModifieer = -2;
            }
            else if (hit.collider.CompareTag("Grava"))
            {
                dragModifieer = -1;
            }
            else if (hit.collider.CompareTag("Tierra"))
            {
                dragModifieer = -2;
            }
            else if (hit.collider.CompareTag("Hielo"))
            {
                dragModifieer = -3;
            }
            theRB.drag = gragOnGround + dragModifieer;
            if (Mathf.Abs(speedInput) > 0)
            {
                theRB.AddForce(transform.forward * speedInput);
                emmisionRate = maxEmission;
            }
        }
        else
        {
            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }

        /*foreach (ParticleSystem parts in dustTrial)
        {
            var emissionModule = parts.emission;
            emissionModule.rateOverTime = emmisionRate;
        }*/

    }
    
}
