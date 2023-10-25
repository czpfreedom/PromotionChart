using System.Collections;
using System.Collections.Generic;
using System.Xml;


public class DiceMapper
{
    public void LoadXML(Dice diceList, string xmlName)
    {
        XmlDocument xml = new();
        xml.Load(xmlName);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("root").SelectNodes("side");

        int i = 0;
        foreach (XmlNode color in xmlNodeList)
        {
            diceList.Description.Add(color.SelectSingleNode("description").InnerText);
            diceList.Probability.Add(float.Parse(color.SelectSingleNode("probability").InnerText));
            i++;
        }
    }
}
