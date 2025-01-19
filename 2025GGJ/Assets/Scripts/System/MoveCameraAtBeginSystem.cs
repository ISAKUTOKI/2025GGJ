using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraAtBeginSystem : MonoBehaviour
{
    [SerializeField] Camera MainCamera;

    float InitialMainCameraSize;
    [SerializeField] float targetMainCameraSize;
    [SerializeField] float mainCameraScaleSpeed;
    [SerializeField] private float waitDuration;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        StartEvents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartEvents()
    {
        ResetVars();
        StartCoroutine(ShowScene());
    }

    IEnumerator ShowScene()
    {
        while (MainCamera.orthographicSize <= targetMainCameraSize)
        {
            MainCamera.orthographicSize = MainCamera.orthographicSize + mainCameraScaleSpeed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(waitDuration);

        while (MainCamera.orthographicSize >= InitialMainCameraSize)
        {
            MainCamera.orthographicSize = MainCamera.orthographicSize - mainCameraScaleSpeed * Time.deltaTime;
            yield return null;
        }

        PlayerBehaviour.Instance.move.canMoveAgain = true;

    }

    private void ResetVars()
    {
        InitialMainCameraSize = MainCamera.orthographicSize;

        PlayerBehaviour.Instance.move.canMoveAgain = false;

        if (targetMainCameraSize == 0)
            targetMainCameraSize = 5;

        if (waitDuration == 0)
            waitDuration = 1.5f;
    }
}
