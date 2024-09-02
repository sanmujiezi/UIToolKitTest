<<<<<<< HEAD
﻿using System.Collections.Generic;
using UnityEngine;

=======
﻿using UnityEngine;
>>>>>>> 0d5b0dccc9a1483ab1347a49575f20d3fdf866e3
[CreateAssetMenu()]
public class NormalDialugue : SingleNode
{
   
    [TextArea] public string dialogueContent;
    
    
    public override Node LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.Waiting;
            if (child != null)
            {
                child.state = State.Running;
                return child;
            }
        }

        return this;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    protected override void OnStart()
    {
        Debug.Log(dialogueContent);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    protected override void OnStop()
    {
        Debug.Log("OnStop");
    }
}