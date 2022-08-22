using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTut : MonoBehaviour
{
    private float yaw = 0.0f, pitch = 0.0f;
    private Rigidbody rb;
    [SerializeField] float walkSpeed = 0.0f, sensivity = 2.0f;
    public Transform chracter;
    void Start()
    {
        //  Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();

    }

    void Update()
    {
        //   if(Input.GetKey(KeyCode.Space) && Physics.Raycast(rb.transform.position,Vector3.down,1+0.001f))
        //      rb.velocity=new Vector3(rb.velocity.x,5.0f,rb.velocity.z);
        Look();
    }

    void Look()
    {
        pitch = -Input.GetAxisRaw("Mouse Y") * sensivity;
        transform.RotateAround(chracter.position, chracter.right, pitch);
        //   pitch+= Mathf.Clamp(pitch,-90.0f,90.0f);
        yaw = Input.GetAxisRaw("Mouse X") * sensivity;
        transform.RotateAround(chracter.position, chracter.up, yaw);
        transform.LookAt(chracter);

        //   Camera.main.transform.localRotation=Quaternion.Euler(pitch,yaw,0);
    }

}
