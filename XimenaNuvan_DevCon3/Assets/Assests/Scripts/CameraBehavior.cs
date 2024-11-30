
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class CameraBehavior : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] float smooth;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = target.position + _offset;
        transform.position = Vector3.SmoothDamp(current: transform.position, targetPos, ref velocity, smooth);
    }
}







