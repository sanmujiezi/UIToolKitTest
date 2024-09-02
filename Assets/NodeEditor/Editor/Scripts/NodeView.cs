using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeView : UnityEditor.Experimental.GraphView.Node
{
   public Node Node;

   public Port input;
   public Port output;
   public Action<NodeView> onNodeSelected;
   public NodeView(Node node)
   {
      this.Node = node;
      this.title = node.name;
      this.viewDataKey = node.guid;
      style.left = node.position.x;
      style.top = node.position.y;
      CreateInputPorts();
      CreateOutputPorts();
   }

   private void CreateInputPorts()
   {
      input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Multi, typeof(bool));
      if (input != null)
      {
         input.portName = "";
         inputContainer.Add(input);
      }
   }

   private void CreateOutputPorts()
   {
      output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(bool));
      if (output != null)
      {
         output.portName = "";
         outputContainer.Add(output);
      }
   }

   public override void OnSelected()
   {
      base.OnSelected();
      if (onNodeSelected != null)
      {
         onNodeSelected.Invoke(this);
      }
   }
}
