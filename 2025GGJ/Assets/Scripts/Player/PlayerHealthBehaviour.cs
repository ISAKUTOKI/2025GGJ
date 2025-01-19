using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBehaviour : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ��Ѫ��ϵͳ
    /// </summary>

    [HideInInspector] public bool canBeHurt = true;



    private void Update()
    {
        if (MapSystemBehaviour.Instance.killZone.isMustBeKilled)
            Die();
    }



    public void TryToDie()
    {
        if (canBeHurt)
            Die();
    }
    public void Die()
    {
        DieEvents();
        //Invoke("DieEvents",2.0f);
    }

    private void DieEvents()
    {

        //PlayerBehaviour.Instance.animator.SetTrigger("Die");
        Debug.Log("isDied");
        //SaveSystemehaviour.Instance.LoadLastSave();

        // ��ȡ��ǰ����������
        string currentSceneName = SceneManager.GetActiveScene().name;
        // ���¼��ص�ǰ����
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
