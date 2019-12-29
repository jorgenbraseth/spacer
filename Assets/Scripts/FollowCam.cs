using System;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField]
    private GameObject following;

    public Vector3 offset;
    public float followSpeed;

    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var followingTransform = following.transform;
        var targetPos = followingTransform.position;
        var myPos = transform.position;

        var distance = (myPos - targetPos);
        distance.Set(distance.x, 0, distance.z);
        var targetCamPos = targetPos + offset;
        
//        transform.position = Vector3.SmoothDamp(myPos, targetCamPos, ref velocity, smoothTime);
        transform.position = Vector3.Lerp(myPos, targetCamPos, Time.deltaTime * followSpeed);
    }

    private void Start()
    {
        transform.LookAt(following.transform.position);
    }
}
