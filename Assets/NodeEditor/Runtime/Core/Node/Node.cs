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
    
    [HideInInspector]public string guid;
    [HideInInspector]public Vector2 position;

    
    public State state = State.Waiting;
    public bool started = false;
    
<<<<<<< HEAD
=======

    // ReSharper disable Unity.PerformanceAnalysis
>>>>>>> 0d5b0dccc9a1483ab1347a49575f20d3fdf866e3
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
