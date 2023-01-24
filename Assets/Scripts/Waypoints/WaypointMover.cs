using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    //[SerializeField] private float topSpeed = 100f;
    [SerializeField] private float tiempoAceleracion = 5f;
    [SerializeField] private float velocidadMedia = 50f;
    //[SerializeField] private float moveSpeedMin = 15f;
    //[SerializeField] private float currentSpeed = 1f;
    private Transform currentWaypoint;
    [SerializeField] private float distanceThresholdMax = 0f;
    [SerializeField] private float distanceThresholdMin = -5f;
    [SerializeField] float velocidadAuto;
    [SerializeField] float intensidad = 5f;
    [SerializeField] float frecuencia = 0.1f;
    private Quaternion rotacion;
    

    void Start()
    {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        //rotacion = Quaternion.LookRotation(currentWaypoint.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime);

        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float oscilacion = Mathf.Sin(Time.time * Mathf.PI * frecuencia) * intensidad + velocidadMedia;
        float acelecion = Mathf.Clamp(Time.time / tiempoAceleracion, 1, 0);
        velocidadAuto = oscilacion *  Time.deltaTime;


        Debug.Log(velocidadAuto);
        //transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Random.Range(moveSpeedMin, moveSpeedMax) * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, velocidadAuto);
        if (Vector3.Distance(transform.position,currentWaypoint.position) < Random.Range(distanceThresholdMin, distanceThresholdMax))
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);           
        }
        rotacion = Quaternion.LookRotation(currentWaypoint.position - transform.position);
        transform.rotation = rotacion;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime);
    }
}
