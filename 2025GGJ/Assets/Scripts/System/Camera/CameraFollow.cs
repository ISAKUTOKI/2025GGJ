using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // 要跟随的目标（通常是玩家）
    [SerializeField] private Vector2 offset = new Vector2(0, 0); // 相机与目标的偏移量
    [SerializeField] private float smoothSpeed = 0.125f; // 相机跟随的平滑速度

    [Header("Camera Bounds")]
    [SerializeField] private float minX = -10f; // 相机最小 X 坐标
    [SerializeField] private float maxX = 10f;  // 相机最大 X 坐标
    [SerializeField] private float minY = -5f;  // 相机最小 Y 坐标
    [SerializeField] private float maxY = 5f;   // 相机最大 Y 坐标

    void LateUpdate()
    {
        if (target == null)
        {
            //Debug.LogWarning("CameraFollow2D: Target is not assigned.");
            return;
        }
        else
        {
            // 计算目标位置
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            // 限制相机移动范围
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
            // 平滑移动
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}