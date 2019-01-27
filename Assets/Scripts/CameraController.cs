using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (player.GetComponent<PlayerController>().finishCamera == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+3.52f, transform.position.z + 2.26f);
            transform.rotation = Quaternion.Euler(90,0,0);
            Debug.Log("Switch to finish Camera");
        }
    }
}
