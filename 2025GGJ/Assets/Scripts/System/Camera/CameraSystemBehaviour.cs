using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystemBehaviour : MonoBehaviour
{
    public GameObject mainCamera;


    public IEnumerator MoveCamera(float moveDistance, Vector3 moveDirection, float moveSpeed)
    {
        
        Debug.Log("摄像机正在移动");
        Vector3 targetPosition = mainCamera.transform.position + moveDirection * moveDistance;

        while (Vector3.Distance(mainCamera.transform.position, targetPosition) > 0.01f)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // 等待下一帧
        }

        mainCamera.transform.position = targetPosition;

        Debug.Log("摄像机移动完了");


        yield return null;
    }
}

