using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Running,
        Waiting
    };

    public State state = State.Waiting;
    public bool started = false;
    public List<Node> children = new List<Node>();

    public Node OnUpdate()
    {
        if (!started)
        {
            OnStart();
            started = true;
        }
        Node currentNode = LogicUpdate();        
        if (state == State.Running)
        {
            OnStop();
            started = false;
        }
        return currentNode;
    }

    public abstract Node LogicUpdate();
    public abstract void OnStart();
    public abstract void OnStop();

}
