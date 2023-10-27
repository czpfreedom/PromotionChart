using Godot;
using System;
using System.Xml;

public partial class NodeUIMapper 
{
    public static void LoadXML(NodeUI nodeUI, XmlNode node, ColorList colorList) {
        XmlNode backGroundNode = node.SelectSingleNode("background");
        XmlNode textNode = node.SelectSingleNode("text");

        //GD.Print(backGroundNode.SelectSingleNode("position").InnerText);
        nodeUI.BackGroundPosition = StringToVector2(backGroundNode.SelectSingleNode("position").InnerText);
        nodeUI.BackGroundScale = StringToVector2(backGroundNode.SelectSingleNode("scale").InnerText);
        nodeUI.BackGroundSize = StringToVector2(backGroundNode.SelectSingleNode("size").InnerText);
        nodeUI.BackGroundColor = colorList.FindValueByName(backGroundNode.SelectSingleNode("color").InnerText);
        nodeUI.BackGroundPressedColor = colorList.FindValueByName(backGroundNode.SelectSingleNode("pressedcolor").InnerText);

        nodeUI.TextPosition = StringToVector2(textNode.SelectSingleNode("position").InnerText);
        nodeUI.TextScale = StringToVector2(textNode.SelectSingleNode("scale").InnerText);
        nodeUI.TextSize = StringToVector2(textNode.SelectSingleNode("size").InnerText);
        nodeUI.TextColor = colorList.FindValueByName(textNode.SelectSingleNode("color").InnerText);
        nodeUI.Text = textNode.SelectSingleNode("text").InnerText;

        string textDirectionStr = textNode.SelectSingleNode("textdirection").InnerText;

        if (textDirectionStr == "Horizontal")
        {
            nodeUI.TextDirection = Config.TextDirection.Horizontal;
        }
        else {
            nodeUI.TextDirection = Config.TextDirection.Vertical;
        }

        //nodeUI.TextDirection = (Config.TextDirection)Enum.Parse(typeof(Config.TextDirection), textNode.SelectSingleNode("textdirection").InnerText);
    }

    public static Vector2 StringToVector2(string stringOrigin) {

        string[] parts = stringOrigin.Split(',');
        float x = float.Parse(parts[0]);
        float y = float.Parse(parts[1]);
        Vector2 vector = new(x, y);
        return vector;
    }

    public static string Vector2ToString(Vector2 vector) { 
        string str = vector.X.ToString() +","+vector.Y.ToString();
        return str;
    }
}
