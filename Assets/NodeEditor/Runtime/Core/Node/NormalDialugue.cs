using System.Collections.Generic;
using UnityEngine;

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

    public override void OnStart()
    {
        Debug.Log(dialogueContent);
    }

    public override void OnStop()
    {
        Debug.Log("OnStop");
    }
}