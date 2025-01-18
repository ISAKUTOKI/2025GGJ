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
    [HideInInspector] public BlowToBottomZone blowToBottomZone;
    [HideInInspector] public BlowDownOneCellZone blowDownOneCellZone;
    [HideInInspector] public DangerZone dangerZone;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        killZone = GetComponentInChildren<KillZone>();
        goBackZone = GetComponentInChildren<MakePlayerGoBackZone>();

        deflectThreeCellsZone = GetComponentInChildren<DeflectThreeCellsZone>();
        blowToBottomZone = GetComponentInChildren<BlowToBottomZone>();
        blowDownOneCellZone = GetComponentInChildren<BlowDownOneCellZone>();
        dangerZone = GetComponentInChildren<DangerZone>();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
