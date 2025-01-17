using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ��Ѫ��ϵͳ
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
