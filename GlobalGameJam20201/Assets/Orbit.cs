using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{


    public Transform centerOfOrbit;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    [SerializeField]
    public float radius = 2.0f;
    [SerializeField]
    public float radiusSpeed = 0.5f;
    [SerializeField]
    public float rotationSpeed = 80.0f;
    [SerializeField]
    GameObject playerHeart;
    // Start is called before the first frame update
    void Start()
    {
        playerHeart = GameObject.FindGameObjectWithTag("Player");
        centerOfOrbit = playerHeart.transform;
        transform.position = (transform.position - centerOfOrbit.position).normalized * radius + centerOfOrbit.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerOfOrbit.position, axis, rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - centerOfOrbit.position).normalized * radius + centerOfOrbit.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}

