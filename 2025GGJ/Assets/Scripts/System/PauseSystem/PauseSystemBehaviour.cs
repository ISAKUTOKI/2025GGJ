using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystemBehaviour : MonoBehaviour
{
    public static PauseSystemBehaviour Instance;
    [HideInInspector] public bool isPausing;
    [SerializeField] private GameObject pauseMenuUIs;

    // 以下为快速重启用的变量
    [SerializeField] private float reloadTime = 1.0f;
    private float _reloadTimer;

    private void Awake()
    {
        // 单例模式
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

    // 初始化变量
    private void InitialVars()
    {
        isPausing = false;
        Time.timeScale = 1.0f;

        if (pauseMenuUIs == null)
        {
            Debug.LogWarning("没有暂停菜单！！");
        }
        else
        {
            pauseMenuUIs.SetActive(false);
        }

        _reloadTimer = reloadTime;
    }

    // 处理重新加载输入
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

    // 暂停游戏
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPausing = true;
        pauseMenuUIs.SetActive(true);
    }

    // 返回游戏
    public void BackToGame()
    {
        Time.timeScale = 1.0f;
        isPausing = false;
        pauseMenuUIs.SetActive(false);
    }

    // 重新加载游戏
    public void ReloadGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}