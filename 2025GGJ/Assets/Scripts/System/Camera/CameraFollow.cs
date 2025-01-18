using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// 相机跟踪系统
    /// </summary>

    [SerializeField] private Transform target; // 要跟随的目标（通常是玩家）
    [SerializeField] private Vector2 offset = new Vector2(0, 0); // 相机与目标的偏移量
    [SerializeField] private float smoothSpeed = 0.125f; // 相机跟随的平滑速度

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
