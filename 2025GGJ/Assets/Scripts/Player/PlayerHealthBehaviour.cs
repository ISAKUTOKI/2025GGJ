using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerHealthBehaviour : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的血量系统
    /// </summary>

    [HideInInspector] public bool canBeHurt = true;
    private float diedDelayTime = 1.5f;
    [SerializeField]private AudioClip audioClip;


    private void Update()
    {
        if (MapSystemBehaviour.Instance.killZone.isMustBeKilled)
            Die();

        if (Input.GetKeyDown(KeyCode.F12))
            TryToDie();
    }



    public void TryToDie()
    {
        if (canBeHurt)
            Die();
    }
    public void Die()
    {
        DieEvents();
    }

    private void DieEvents()
    {
        if (PlayerBehaviour.Instance.animator != null)
        {
            PlayerBehaviour.Instance.animator.SetTrigger("Die");
            AudioSystemBehaviour.Instance.effectSource.PlayOneShot(audioClip, 0.4f);
            Debug.Log("播放了死亡动画");
        }
        Debug.Log("isDied");
        //SaveSystemehaviour.Instance.LoadLastSave();
        Invoke("LoadCurrentScene", diedDelayTime);
    }
    void LoadCurrentScene()
    {

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
