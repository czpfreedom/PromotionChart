using Godot;
using System;
using System.Xml;

public  class ColorListMapper
{
    public static void  LoadXML(ColorList colorList, string xmlName)
    {
        XmlDocument xml = new();
        xml.Load(xmlName);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("root").SelectNodes("color");

        int i = 0;
        foreach (XmlNode color in xmlNodeList) {
            colorList.Names.Add( color.SelectSingleNode("name").InnerText);
            colorList.Values.Add(color.SelectSingleNode("value").InnerText);
            i++;
        }
    }
}
