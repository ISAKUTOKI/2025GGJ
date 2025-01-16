using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public void SetPlayerV3Position(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }

    public void SetPlayerV2Posion(float x,float y)
    {
        transform.position=new Vector2(x,y);
    }///大抵是用不到的，但还是先放这
}
