using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Vector3 offset = new Vector3();
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -1.0f) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
