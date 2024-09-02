using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class NodeTree : ScriptableObject
{
    public Node rootNode;
    public Node runningNode;
    public Node.State treeState = Node.State.Waiting;
    public List<Node> nodes = new List<Node>();

    public virtual void Update()
    {
        if (treeState ==  Node.State.Running && runningNode.state == Node.State.Running)
        {
            runningNode = runningNode.OnUpdate();
        }
        
    }

    public virtual void OnTreeStart()
    {
        treeState = Node.State.Running;
        runningNode.state = Node.State.Running;
    }

    public virtual void OnTreedEnd()
    {
        treeState = Node.State.Waiting;
        runningNode.state = Node.State.Waiting;
    }
<<<<<<< HEAD
=======
    
>>>>>>> 0d5b0dccc9a1483ab1347a49575f20d3fdf866e3
#if UNITY_EDITOR
    public Node CreateNode(System.Type type){
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name =type.Name;
        node.guid = GUID.Generate().ToString();
         
        nodes.Add(node);
        if(!Application.isPlaying){
            AssetDatabase.AddObjectToAsset(node,this);
        }
        AssetDatabase.SaveAssets();
        return node;
    }
    public Node DeleteeNode(Node node){
        nodes.Remove(node);
        AssetDatabase.RemoveObjectFromAsset(node);
        // Undo.DestroyObjectImmediate(node);
        AssetDatabase.SaveAssets();
        return node;
    }
#endif
<<<<<<< HEAD
    
=======
   
>>>>>>> 0d5b0dccc9a1483ab1347a49575f20d3fdf866e3
}