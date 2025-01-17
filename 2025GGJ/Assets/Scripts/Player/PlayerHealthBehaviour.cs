using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的血量系统
    /// </summary>

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
            Die();
    }

    private void Hurt()
    {

    }

    private void Die()
    {
        Debug.Log("isDied");
        SaveSystemehaviour.Instance.LoadLastSave();
    }


 

    [HideInInspector]
    public int health
    {
        get
        {
            return health;
        }
        set
        {
            health = Mathf.Max(value, 0);
        }
    }
}
