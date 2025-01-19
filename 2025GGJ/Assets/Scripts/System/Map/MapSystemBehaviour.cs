using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystemBehaviour : MonoBehaviour
{
    public static MapSystemBehaviour Instance;

    /// <summary>
    /// 以下为基础格
    /// </summary>
    [HideInInspector] public KillZone killZone;
    [HideInInspector] public MakePlayerGoBackZone goBackZone;

    /// <summary>
    /// 以下为特殊格
    /// </summary>
    [HideInInspector] public DeflectThreeCellsZone deflectThreeCellsZone;
    [HideInInspector] public BlowDownOneCellZone blowDownOneCellZone;
    [HideInInspector] public DangerZone dangerZone;
    [HideInInspector] public ExtendZone extendZone;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        killZone = GetComponentInChildren<KillZone>();
        goBackZone = GetComponentInChildren<MakePlayerGoBackZone>();

        deflectThreeCellsZone = GetComponentInChildren<DeflectThreeCellsZone>();
        blowDownOneCellZone = GetComponentInChildren<BlowDownOneCellZone>();
        dangerZone = GetComponentInChildren<DangerZone>();
        extendZone = GetComponentInChildren<ExtendZone>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
