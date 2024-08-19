using UnityEngine;

public class BranchDialogue : CompositeNode
{
    [TextArea] public string dialogueContent;
    public int nextDialogueIndex = 0;
    
    public override Node LogicUpdate()
    {
        if (Input.GetKeyDown((KeyCode.A)))
        {
            nextDialogueIndex = 0;
        }

        if (Input.GetKeyDown((KeyCode.B)))
        {
            nextDialogueIndex = 1;
        }

        if (Input.GetKeyDown((KeyCode.Space)))
        {
            state = State.Waiting;
            if (children.Count > nextDialogueIndex)
            {
                children[nextDialogueIndex].state = State.Running;
                return children[nextDialogueIndex];
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
