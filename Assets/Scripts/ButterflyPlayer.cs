using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyPlayer : MonoBehaviour
{
    Rigidbody myRigidBody;
    [SerializeField] float flySpeed = 15f;
    [SerializeField] float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        fly();

        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.AddRelativeForce(Vector3.up * flySpeed);
        }
    }

    private void Rotate()
    {
        myRigidBody.freezeRotation = true;
        float inputAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * inputAxis * rotateSpeed);
        myRigidBody.freezeRotation = false;
    }
}
