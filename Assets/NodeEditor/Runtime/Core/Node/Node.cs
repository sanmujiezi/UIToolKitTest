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
    
    [HideInInspector]public string guid;
    [HideInInspector]public Vector2 position;

    
    public State state = State.Waiting;
    public bool started = false;
    

    // ReSharper disable Unity.PerformanceAnalysis
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
    protected abstract void OnStart();
    protected abstract void OnStop();

}
