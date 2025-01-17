using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public static UIBehaviour Instance;

    public PauseMenuBehaviour pauseMenuSystem { get; private set; }
    public StartMenuBehaviour startMenuSystem { get; private set; }
    public OptionMenuBehaviour optionMenuSystem { get; private set; }

    public GameObject pauseMenuUI;
    public GameObject startMenuUI;
    public GameObject optionMenuUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pauseMenuSystem = GetComponentInChildren<PauseMenuBehaviour>();
        startMenuSystem = GetComponentInChildren<StartMenuBehaviour>();
        optionMenuSystem = GetComponentInChildren<OptionMenuBehaviour>();
    }

}
