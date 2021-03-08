using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButterflyPlayer : MonoBehaviour
{
    Rigidbody myRigidBody;
    [SerializeField] float flySpeed = 15f;
    [SerializeField] float rotateSpeed;
    [SerializeField] ParticleSystem dustFX;
    [SerializeField] GameObject explodeFX;
    bool isAlive = true;
    int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            fly();

            Rotate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bad") ;
        {
            Instantiate(explodeFX, transform.position, transform.rotation);
            
            isAlive = false;
            

            Invoke("ResetScene", 2f);
        }
        if (collision.gameObject.tag == "win")
        {
            SceneManager.LoadScene(currentLevel * 1);
        }

    }

    void fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.AddRelativeForce(Vector3.up * flySpeed);
            dustFX.Play();
        }
        else
        {
            dustFX.Stop();
        }
    
    }

    private void Rotate()
    {
        myRigidBody.freezeRotation = true;
        float inputAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * inputAxis * rotateSpeed);
        myRigidBody.freezeRotation = false;
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(currentLevel);
    }
}
