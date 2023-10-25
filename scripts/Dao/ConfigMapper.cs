using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class ConfigMapper
{
    public static void LoadXML(Config config, string xmlName) {
        XmlDocument xml = new();
        xml.Load(xmlName);
        XmlNode root = xml.SelectSingleNode("set");

    }
}
