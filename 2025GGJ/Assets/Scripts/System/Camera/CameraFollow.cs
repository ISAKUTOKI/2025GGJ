using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// �������ϵͳ
    /// </summary>

    [SerializeField] private Transform target; // Ҫ�����Ŀ�꣨ͨ������ң�
    [SerializeField] private Vector2 offset = new Vector2(0, 0); // �����Ŀ���ƫ����
    [SerializeField] private float smoothSpeed = 0.125f; // ��������ƽ���ٶ�

    void LateUpdate()
    {
        if (target == null)
        {
            //Debug.LogWarning("CameraFollow2D: Target is not assigned.");
            return;
        }

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
