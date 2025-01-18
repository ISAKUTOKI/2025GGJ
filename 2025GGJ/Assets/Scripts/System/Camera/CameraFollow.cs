using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Ҫ�����Ŀ�꣨ͨ������ң�
    [SerializeField] private Vector2 offset = new Vector2(0, 0); // �����Ŀ���ƫ����
    [SerializeField] private float smoothSpeed = 0.125f; // ��������ƽ���ٶ�

    [Header("Camera Bounds")]
    [SerializeField] private float minX = -10f; // �����С X ����
    [SerializeField] private float maxX = 10f;  // ������ X ����
    [SerializeField] private float minY = -5f;  // �����С Y ����
    [SerializeField] private float maxY = 5f;   // ������ Y ����

    void LateUpdate()
    {
        if (target == null)
        {
            //Debug.LogWarning("CameraFollow2D: Target is not assigned.");
            return;
        }
        else
        {
            // ����Ŀ��λ��
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            // ��������ƶ���Χ
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
            // ƽ���ƶ�
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}