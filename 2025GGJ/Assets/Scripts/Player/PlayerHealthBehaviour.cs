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
    [SerializeField] private float diedDelayTime=3.0f;


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
        if(PlayerBehaviour.Instance.animator!=null)
        {
            PlayerBehaviour.Instance.animator.SetTrigger("Die");
            Debug.Log("��������������");
        }
        Debug.Log("isDied");
        //SaveSystemehaviour.Instance.LoadLastSave();
        Invoke("LoadCurrentScene", diedDelayTime);
    }
    void LoadCurrentScene()
    {

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
