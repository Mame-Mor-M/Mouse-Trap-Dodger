using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // The target the camera will follow
    public float smoothTime = 0.1f;
    public float speed = 3.0f;

    public float followDistance = 10f;
    public float verticalBuffer = 1.5f;
    public float horizontalBuffer = 0f;

    private Vector3 velocity = Vector3.zero;


    public float yRotation = 0.0f;

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(horizontalBuffer, followDistance, verticalBuffer));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.eulerAngles = new Vector3(0, target.transform.eulerAngles.y, 0);
        //------------------------------------------------------------------------
    }
}