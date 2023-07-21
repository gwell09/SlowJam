using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that's on game objects following the cursor's current position
/// </summary>
public class CursorFollower : MonoBehaviour
{
    public Vector3 cursorPos
    {
        get { return Input.mousePosition; }
    }

    public bool shouldFollowCursor;

    public Vector3 GetCursorPosInWorldSpace()
    {
        Vector3 pos = new Vector3(cursorPos.x, cursorPos.y, 0f);
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0f;
        return pos;
    }

    public Vector3 GetCursorPosInWorldSpace(float zPos) 
    {
        Vector3 pos = new Vector3(cursorPos.x, cursorPos.y, zPos);
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = zPos;
        return pos;
    }

    public void SetShouldFollow(bool b)
    {
       shouldFollowCursor = b;
    }

    private void Update()
    {
        if(shouldFollowCursor)
        {
            transform.position = GetCursorPosInWorldSpace();
        }
    }
}
