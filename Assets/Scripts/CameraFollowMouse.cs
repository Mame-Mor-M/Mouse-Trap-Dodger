using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float speedH = 2f;
    public float speedV = 2f;

    public float yaw = 0f;
    public float pitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH*Input.GetAxis("Mouse X");
        pitch -= speedV*Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -35, 60);
        yaw = Mathf.Clamp(yaw, -35, 35);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
