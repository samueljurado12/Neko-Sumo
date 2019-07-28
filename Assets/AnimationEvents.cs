using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void SetSpeed(int speed)
    {
        transform.parent.GetComponent<CharacterMovement>().Speed = speed;
    }
}
