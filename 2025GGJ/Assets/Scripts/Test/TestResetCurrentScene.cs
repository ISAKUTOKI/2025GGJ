using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResetCurrentScene : MonoBehaviour
{
    public void ResetCurrentScene()
    {
        PlayerBehaviour.Instance.health.Die();
    }
}
