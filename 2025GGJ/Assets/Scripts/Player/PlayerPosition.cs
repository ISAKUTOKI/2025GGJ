using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [HideInInspector]
    public void SetPlayerV3Position(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    [HideInInspector]
    public void SetPlayerV2Position(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }///大抵是用不到的，但还是先放这

    [HideInInspector]
    public Vector3 currentPlayerPosition
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
}
