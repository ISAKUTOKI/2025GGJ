using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystemBehaviour : MonoBehaviour
{
    public GameObject mainCamera;


    public IEnumerator MoveCamera(float moveDistance, Vector3 moveDirection, float moveSpeed)
    {
        
        Debug.Log("����������ƶ�");
        Vector3 targetPosition = mainCamera.transform.position + moveDirection * moveDistance;

        while (Vector3.Distance(mainCamera.transform.position, targetPosition) > 0.01f)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }

        mainCamera.transform.position = targetPosition;

        Debug.Log("������ƶ�����");


        yield return null;
    }
}

