using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UIElements;
using Edge = UnityEditor.Experimental.GraphView.Edge;

public class NodeTreeViewer : GraphView
{
    public NodeTree tree;
    public new class UxmlFactory : UxmlFactory<NodeTreeViewer,GraphView.UxmlTraits>{}

    public NodeTreeViewer()
    {
        Insert(0,new GridBackground());
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/NodeEditor/Editor/UI/NodeTreeViewer.uss");
        styleSheets.Add(styleSheet);
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        var types = TypeCache.GetTypesDerivedFrom<Node>();
        foreach (var type in types)
        {
            evt.menu.AppendAction($"{type.Name}",(a) => CreateNode(type));
        }
    }

    private void CreateNode(Type type)
    {
        Node node = tree.CreateNode(type);
        NodeView nodeView = new NodeView(node);
        AddElement(nodeView);
    }

    internal void PopulateView(NodeTree tree)
    {
        this.tree = tree;
        DeleteElements(graphElements);
    }

    /*private onGraphViewChange(GraphViewChange graphViewChange)
    {
        if (graphViewChange.elementsToRemove != null)
        {
            graphViewChange.elementsToRemove.ForEach(elem =>
            {
                NodeView nodeView = elem as NodeView;
                if (nodeView != null)
                {
                    tree.DeleteeNode(nodeView.Node);
                }
                Edge edge = elem as Edge;
                if (edge != null)
                {
                    
                }
            });
        }
    }*/

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        return ports.ToList().Where(
            endport => endport.direction != startPort.direction
            && endport.node != startPort.node).ToList();
    }
}
