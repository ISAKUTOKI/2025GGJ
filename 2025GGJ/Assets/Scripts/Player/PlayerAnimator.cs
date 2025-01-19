using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private void FlipView(Vector3 direction)
    {
        if (direction == Vector3.left)
        {
            PlayerBehaviour.Instance.view.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction == Vector3.right)
        {
            PlayerBehaviour.Instance.view.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void SwitchAnimator(Vector3 direction)
    {
        if (direction == Vector3.left)
        {
            FlipView(Vector3.left);
            PlayerBehaviour.Instance.animator.SetTrigger("MoveHorizontal");
        }
        else if (direction == Vector3.right)
        {
            FlipView(Vector3.right);
            PlayerBehaviour.Instance.animator.SetTrigger("MoveHorizontal");
        }
        else if (direction == Vector3.up)
        {
            PlayerBehaviour.Instance.animator.SetTrigger("MoveUp");

        }
        else if (direction == Vector3.down)
        {
            PlayerBehaviour.Instance.animator.SetTrigger("MoveDown");
        }
    }
}
