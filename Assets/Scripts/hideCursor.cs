using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideCursor : MonoBehaviour
{
    // https://docs.unity3d.com/ScriptReference/Cursor-visible.html
    void Start()
    {
        // to set the cursor invisible
        Cursor.visible = false;
    }
}
