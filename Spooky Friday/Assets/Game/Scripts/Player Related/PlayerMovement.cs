using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    [SerializeField] private Animator animator;
    private Vector3 _input;

    [SerializeField] private bool isJoystick;
    [SerializeField] private bool useSkewedInput;

    [SerializeField] private FixedJoystick joystick;
    private SpawnManager _spawnManager;
    private bool isDead;
    private void Awake()
    {
        joystick = GameObject.FindObjectOfType<FixedJoystick>();
        _spawnManager = SpawnManager.instance;
        isDead = false;

    }

    private void Start()
    {
        CameraManager.instance.UpdateTarget(this.transform);
    }

    private void Update()
    {
        if(isDead) return;
        
        GatherInput(isJoystick);
        Look();
        Animate();
    }

    private void FixedUpdate()
    {
        if(isDead)  return;
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

    private bool ismove;
    private static readonly int Movehash = Animator.StringToHash("Move");
    private static readonly int IsDead = Animator.StringToHash("isDead");

    private void Animate()
    {
        if ((joystick.Horizontal == 0 && joystick.Vertical == 0))
            ismove = false;
        else
            ismove = true;
        
        animator.SetBool(Movehash,ismove);
    }
    [ContextMenu("Delete Player")]
    public void DestroyPlayer()
    {
        isDead = true;
        animator.SetTrigger(IsDead);
        rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;
        StartCoroutine(nameof(SpawnNewPlayer));
    }

    IEnumerator SpawnNewPlayer()
    {
        yield return new WaitForSeconds(1.5f);
       // transform.DOScale(Vector3.zero, 0.15f);
        _spawnManager.RespawnPlayer();
    }
}