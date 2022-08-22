using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoıntTeleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject chracter;
    public PlayerController playerControllerScript;
    public GameObject chracterPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void TeleportToObject()
    {
        chracter.transform.position = teleportTarget.transform.position;
        chracter.transform.position = new Vector3(chracter.transform.position.x, chracter.transform.position.y + 2, chracter.transform.position.z);
        Debug.Log("buton calisti");
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            teleportTarget = other.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            TeleportToObject();
        }
        else if (playerControllerScript.isDead)
        {
            Instantiate(chracterPrefab, teleportTarget.transform.position, Quaternion.identity);
            playerControllerScript.isDead = false;
        }
    }

}
