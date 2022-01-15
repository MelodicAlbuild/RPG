using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    public bool active = false;
    void Update()
    {
        if (active)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void Enable()
    {
        active = true;
    }

    public void Disable()
    {
        active = false;
    }
}
