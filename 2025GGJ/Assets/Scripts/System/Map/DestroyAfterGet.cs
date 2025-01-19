using System.Collections;
using UnityEngine;

public class DestroyAfterGet : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0f; // �����ӳ�ʱ��
    [SerializeField] private ParticleSystem collectEffect; // �ռ���Ч

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��鴥�������Ƿ������
        if (other.gameObject.CompareTag("Player"))
        {
            // ��������Ч��
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // �ӳ����ٶ���
            StartCoroutine(DestroyAfterDelay(destroyDelay));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // �ȴ�ָ�����ӳ�ʱ��
        yield return new WaitForSeconds(delay);

        // ���ٶ���
        Destroy(gameObject);
    }
}