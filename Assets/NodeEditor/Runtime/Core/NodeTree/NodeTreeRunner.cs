using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeTreeRunner : MonoBehaviour
{
    public NodeTree tree;
    private bool _istreeNotNull;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            tree.OnTreeStart();
        }
        
        if (tree != null)
        {
            tree.Update();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            tree.OnTreedEnd();
        }
            
        
    }
}
