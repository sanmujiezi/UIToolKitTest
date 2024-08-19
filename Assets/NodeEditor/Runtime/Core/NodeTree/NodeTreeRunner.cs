using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeTreeRunner : MonoBehaviour
{
    public NodeTree tree;
    private bool _istreeNotNull;

    private void Start()
    {
        _istreeNotNull = tree != null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            tree.OnTreeStart();
        }
        
        if (_istreeNotNull)
        {
            tree.Update();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            tree.OnTreedEnd();
        }
            
        
    }
}
