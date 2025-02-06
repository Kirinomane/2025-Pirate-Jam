using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private shield_controller ctrl;

    public float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset = new Vector3(0f, 20f, -20f);
    public Vector3 fixedOffset = new Vector3(0f, 5f, -5f);

    private Vector3 desiredPosition;
    //    public Vector2 panLimit;

    [HideInInspector] public static CameraFollow instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        ctrl = target.GetComponent<shield_controller>();
    }

    void LateUpdate()
    {

        if (ctrl.active)
        {
            desiredPosition = target.position + fixedOffset;
            //transform.LookAt(target);
        }
        else
        {
            desiredPosition = target.position + offset;
            //transform.LookAt(target);
        }

        transform.position = desiredPosition;

        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;



    //    transform.LookAt(target);
    }
}
