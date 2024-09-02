using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    
    [HideInInspector]public string guid;
    [HideInInspector]public Vector2 position;
    public enum State
    {
        Running,
        Waiting
    };

    public State state = State.Waiting;
    public bool started = false;
    
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
