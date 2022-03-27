using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float _speed = 3;
    [SerializeField] private float _jumpForce = 200;
    [SerializeField] public Rigidbody _rb;
    public Transform cameraWay;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        var velX = Input.GetAxis("Horizontal") * cameraWay.right;
        var velF = Input.GetAxis("Vertical") * cameraWay.forward;
        var vel = velX * _speed + velF * _speed;

        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
        if (Input.GetKeyDown(KeyCode.Space)) _rb.AddForce(Vector3.up * _jumpForce);
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.gameObject.name);
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.GetComponent<Collider>().gameObject.name);
    }
}
