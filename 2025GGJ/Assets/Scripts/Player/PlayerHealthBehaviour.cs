using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    }

    private void Hurt()
    {

    }

    public void Die()
    {
        Debug.Log("isDied");
        //SaveSystemehaviour.Instance.LoadLastSave();

        // 获取当前场景的名称
        string currentSceneName = SceneManager.GetActiveScene().name;
        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneName);
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
