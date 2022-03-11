using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 _input;

    [SerializeField] private bool isJoystick;
    [SerializeField] private bool useSkewedInput;

    [SerializeField] private DynamicJoystick joystick;
    private SpawnManager _spawnManager;
    private void Awake()
    {
        joystick = GameObject.FindObjectOfType<DynamicJoystick>();
        _spawnManager = SpawnManager.instance;

    }

    private void Start()
    {
       // CameraManager.instance.UpdateTarget(this.transform);
    }

    private void Update()
    {
        GatherInput(isJoystick);
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput(bool useJoystick)
    {
        _input = useJoystick
            ? new Vector3(joystick.Horizontal, 0, joystick.Vertical)
            : new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;
        var rot = useSkewedInput
            ? Quaternion.LookRotation(_input.ToIso(), Vector3.up)
            : Quaternion.LookRotation(_input, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _spawnManager.RespawnPlayer();
    }
    [ContextMenu("Delete Player")]
    public void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }
}