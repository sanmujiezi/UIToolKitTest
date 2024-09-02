using UnityEngine;

[CreateAssetMenu()]
public class DialogTree : NodeTree
{
    public override void OnTreeStart()
    {
        base.OnTreeStart();
        runningNode.state = Node.State.Running;
        rootNode.state = Node.State.Running;
    }
}