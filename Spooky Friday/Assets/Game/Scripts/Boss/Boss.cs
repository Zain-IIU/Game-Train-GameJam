using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss Instance;
    [SerializeField] private Transform target;

    [SerializeField] private GameObject venomPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform spitPos;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private bool isPlayerSeen;

    [SerializeField] private Animator animator;

    private static readonly int SeenPlayer = Animator.StringToHash("seenPlayer");

    // Start is called before the first frame update
    void Start()
    {
       // isPlayerSeen = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!isPlayerSeen) return;
        Vector3 lookAtGoal = new Vector3(target.position.x,
            transform.position.y,
            target.position.z);
        transform.LookAt(lookAtGoal);
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void StartAttack()
    {
        isPlayerSeen = true;
        animator.SetTrigger(SeenPlayer);
    }

    [SerializeField] private float timetoReach;
    [SerializeField] private Ease _ease;
    public void SpitVenom()
    {
        GameObject venom = Instantiate(venomPrefab, spawnPos.position, quaternion.identity);
        venom.transform.DOMove(spitPos.position, timetoReach).SetEase(_ease).OnComplete(() =>
        {
            venom.GetComponent<Poison>().EnablePoison();
        });
    }
}

