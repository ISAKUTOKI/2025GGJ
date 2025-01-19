using System.Collections;
using UnityEngine;

public class DestroyAfterGet : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0f; // 销毁延迟时间
    [SerializeField] private ParticleSystem collectEffect; // 收集特效

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查触发对象是否是玩家
        if (other.gameObject.CompareTag("Player"))
        {
            // 播放粒子效果
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // 延迟销毁对象
            StartCoroutine(DestroyAfterDelay(destroyDelay));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // 等待指定的延迟时间
        yield return new WaitForSeconds(delay);

        // 销毁对象
        Destroy(gameObject);
    }
}