using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PauseSystemBehaviour : MonoBehaviour
{
    public static PauseSystemBehaviour Instance;
    [HideInInspector] public bool isPausing;
    [SerializeField] private GameObject pauseMenuUIs;
    private void Awake()
    {
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
    // Start is called before the first frame update
    void Start()
    {
        InitialVars();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPausing && Input.GetKeyDown(KeyCode.Escape))
        {

        }
        else if (isPausing && Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPausing = true;
        pauseMenuUIs.SetActive(true);
    }
    public void BackToGame()
    {
        Time.timeScale = 1.0f;
        isPausing = false;
        pauseMenuUIs.SetActive(false);
    }

    private void InitialVars()
    {
        isPausing = false;
        Time.timeScale = 1.0f;

        if (pauseMenuUIs == null)
        {
            Debug.LogWarning("Ã»ÓÐÔÝÍ£²Ëµ¥£¡£¡");
            return;
        }
        else
        {
            pauseMenuUIs.SetActive(false);
        }
    }
}
