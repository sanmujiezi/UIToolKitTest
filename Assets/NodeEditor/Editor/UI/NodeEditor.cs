using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class NodeEditor : EditorWindow
{
    public NodeTreeViewer nodeTreeViewer;
    [MenuItem("Window/UI Toolkit/NodeEditor")]
    public static void ShowExample()
    {
        NodeEditor wnd = GetWindow<NodeEditor>();
        wnd.titleContent = new GUIContent("NodeEditor");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/NodeEditor/Editor/UI/NodeEditor.uxml");
        visualTree.CloneTree(root);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/NodeEditor/Editor/UI/NodeEditor.uss");
        root.styleSheets.Add(styleSheet);
        nodeTreeViewer = root.Q<NodeTreeViewer>();
    }

    private void OnSelectionChange()
    {
        
            NodeTree tree = Selection.activeObject as NodeTree;
            nodeTreeViewer.PopulateView(tree);
        
    }
}