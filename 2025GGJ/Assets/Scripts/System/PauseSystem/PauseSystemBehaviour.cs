using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystemBehaviour : MonoBehaviour
{
    public static PauseSystemBehaviour Instance;
    [HideInInspector] public bool isPausing;
    [SerializeField] private GameObject pauseMenuUIs;

    // ����Ϊ���������õı���
    [SerializeField] private float reloadTime = 1.0f;
    private float _reloadTimer;

    private void Awake()
    {
        // ����ģʽ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitialVars();
    }

    private void Update()
    {
        HandleReloadInput();
    }

    // ��ʼ������
    private void InitialVars()
    {
        isPausing = false;
        Time.timeScale = 1.0f;

        if (pauseMenuUIs == null)
        {
            Debug.LogWarning("û����ͣ�˵�����");
        }
        else
        {
            pauseMenuUIs.SetActive(false);
        }

        _reloadTimer = reloadTime;
    }

    // �������¼�������
    private void HandleReloadInput()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _reloadTimer -= Time.deltaTime;
            if (_reloadTimer <= 0)
            {
                ReloadGame();
            }
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            _reloadTimer = reloadTime;
        }
    }

    // ��ͣ��Ϸ
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPausing = true;
        pauseMenuUIs.SetActive(true);
    }

    // ������Ϸ
    public void BackToGame()
    {
        Time.timeScale = 1.0f;
        isPausing = false;
        pauseMenuUIs.SetActive(false);
    }

    // ���¼�����Ϸ
    public void ReloadGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}