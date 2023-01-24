using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public float velocidadMaxima;
    [SerializeField] public float velocidadActual = 0;
    public float pitch = 1;
    [SerializeField] AudioSource sonidoMotor;
    [SerializeField] AudioClip sonidoclaxon;
    [SerializeField] AudioSource claxon;
    public float minimaAltura = 1f;
    public float maximaAltura = 1.7f;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] public float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private Rigidbody rb;
    public Transform center;
    private Transform groundRayPoint;

    private GameController gameController = null;

    
    [SerializeField] public GameObject aguja;
    private float posicionInicioAguja =226, posicionFinAguja=-50;
    private float irAPosicion;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        sonidoMotor = GetComponent<AudioSource>();
        sonidoMotor.pitch = minimaAltura;
        pitch = GetComponent<AudioSource>().pitch;

    }
    public void MoverAguja()
    {
        irAPosicion = posicionInicioAguja - posicionFinAguja;
        float temp =  velocidadActual / 180;
        aguja.transform.eulerAngles = new Vector3(0, 0, (posicionInicioAguja - temp * irAPosicion)); 
    }

    private void FixedUpdate()
    {
        if (gameController.enableCar)
        {
            GetInput();
            Acelerate();
            HandleSteering();
            UpdateWheels();
            rb.centerOfMass = center.localPosition;
            GripControlRearRight();
            GripControlRearLeft();
            //GripControl(frontLeftWheelCollider);
            //GripControl(frontRightWheelCollider);
            MoverAguja();
        }

    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);

        if (verticalInput < 0)
        {
            isBreaking = true;
        }
        else
        {
            isBreaking = false;
        }
        //isBreaking = Input.GetKey(KeyCode.Space);
        if (Input.GetKey(KeyCode.Space))
        {
            verticalInput = -1;
        }
    }

    private void Acelerate()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        velocidadMaxima = 70;
        //Debug.Log(velocidadMaxima = frontLeftWheelCollider.motorTorque);

        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
        //Debug.Log(frontLeftWheelCollider);
    }

    void Update()
    {
        velocidadActual = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;

        //pitch = velocidadActual / velocidadMaxima;

        sonidoMotor.pitch = Mathf.Clamp (  ( 1.5f / velocidadMaxima ) * velocidadActual  , 0.1f , 1.5f );

        

        //Debug.Log(velocidadActual);

        /*if (velocidadMaxima < minimaAltura)
        {
            sonidoMotor.pitch = minimaAltura;
        }
        else if (velocidadMaxima > maximaAltura)
        {
            sonidoMotor.pitch = maximaAltura;
        }
        else
        {
            sonidoMotor.pitch = velocidadMaxima;
        }
        //se limita la velocidad del engine la limitamos a los máximos y mínimos del pitch
        */
        if (Input.GetKeyDown(KeyCode.W))
        {
            claxon.PlayOneShot(sonidoclaxon);
        }


        }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    private void GripControlRearLeft()
    {


        WheelHit hit;
        if (rearLeftWheelCollider.GetGroundHit(out hit))
        {
            WheelFrictionCurve fFriction = rearLeftWheelCollider.forwardFriction;
            fFriction.stiffness = hit.collider.material.staticFriction;
            rearLeftWheelCollider.forwardFriction = fFriction;
            WheelFrictionCurve sFriction = rearLeftWheelCollider.sidewaysFriction;
            sFriction.stiffness = hit.collider.material.staticFriction;
            rearLeftWheelCollider.sidewaysFriction = sFriction;
        }
    }
    private void GripControlRearRight()
    {
        WheelHit hit;
        if (rearRightWheelCollider.GetGroundHit(out hit))
        {
            WheelFrictionCurve fFriction = rearRightWheelCollider.forwardFriction;
            fFriction.stiffness = hit.collider.material.staticFriction;
            rearRightWheelCollider.forwardFriction = fFriction;
            WheelFrictionCurve sFriction = rearRightWheelCollider.sidewaysFriction;
            sFriction.stiffness = hit.collider.material.staticFriction;
            rearRightWheelCollider.sidewaysFriction = sFriction;
        }
    }
    private void GripControl(WheelCollider wheelCollider)
    {
        WheelHit hit;
        if (wheelCollider.GetGroundHit(out hit))
        {
            WheelFrictionCurve fFriction = wheelCollider.forwardFriction;
            fFriction.stiffness = hit.collider.material.staticFriction;
            wheelCollider.forwardFriction = fFriction;
            WheelFrictionCurve sFriction = wheelCollider.sidewaysFriction;
            sFriction.stiffness = hit.collider.material.staticFriction;
            wheelCollider.sidewaysFriction = sFriction;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        IPowerup powerup = other.GetComponent<IPowerup>();
        if (powerup != null)
        {
            float res = powerup.OpenPowerup();
            if (powerup.getID() == (int)PowerupId.MOTORFORCE)
            {
                motorForce = res;
            }
            Destroy(other.gameObject); 
        }
    }
}
