using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    }

    private void Hurt()
    {

    }

    public void Die()
    {
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
