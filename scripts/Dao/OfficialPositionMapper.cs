using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class OfficialPositionMapper 
{
    public static void LoadXML(DepartmentList departmentList, OfficialPositionList officialPositionList, string xmlName, ColorList colorList)
    {

        XmlDocument xml = new();
        xml.Load(xmlName);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("root").SelectNodes("officialposition");


        OfficialPosition officialPosition;
        officialPositionList.List = new List<OfficialPosition>();   

        int i = 0;
        foreach (XmlNode officialPositionNode in xmlNodeList)
        {
            officialPosition = new OfficialPosition
            {
                Department = departmentList.FindDepartmentByName(officialPositionNode.SelectSingleNode("department").InnerText.Replace(" ", "")),
                Description = officialPositionNode.SelectSingleNode("description".Replace(" ", "")).InnerText
            };
            if (officialPositionNode.SelectSingleNode("isMaster").InnerText == "True")
            {
                officialPosition.IsMaster = true;
            }
            else
            {
                officialPosition.IsMaster = false;
            }
            officialPosition.Level = int.Parse(officialPositionNode.SelectSingleNode("level").InnerText);
            officialPosition.Name = officialPositionNode.SelectSingleNode("name").InnerText.Replace(" ","");
            officialPosition.Chinesename = officialPositionNode.SelectSingleNode("chinesename").InnerText.Replace(" ", "");
            officialPositionList.List.Add(officialPosition);

            i++;        
        }



        // 概率信息
        i = 0;
        
        foreach (XmlNode officialPositionNode in xmlNodeList)
        {
            int j = 0;
            XmlNodeList nextofficialpositionprobabilityNodeList = officialPositionNode.SelectNodes("officialpositionprobability");
            officialPositionList.List[i].NextOfficialPositionProbability = new OfficialPositionProbability();
            foreach (XmlNode node in nextofficialpositionprobabilityNodeList)
            {
               OfficialPosition nextOfficialPosition = new();
                nextOfficialPosition = officialPositionList.FindOfficialPositionByName(node.SelectSingleNode("officialposition").InnerText);
                officialPositionList.List[i].NextOfficialPositionProbability.NextOfficialPosition.Add(nextOfficialPosition);

                float nextOfficialPositionProbability = float.Parse(node.SelectSingleNode("probability").InnerText);
                officialPositionList.List[i].NextOfficialPositionProbability.Probability.Add(nextOfficialPositionProbability);
                j++;
            }
            officialPositionList.List[i].NextOfficialPositionProbability.Num = j;
            i++;
        }

        // UI信息
        i = 0;

        foreach (XmlNode officialPositionNode in xmlNodeList)
        {
            officialPositionList.List[i].PositionNodeUI = new NodeUI();
            XmlNode UINode = officialPositionNode.SelectSingleNode("UI");
            NodeUIMapper.LoadXML(officialPositionList.List[i].PositionNodeUI, UINode, colorList);

            officialPositionList.List[i].GradeNodeUI = new NodeUI();
            UINode = officialPositionNode.SelectSingleNode("GradeUI");
            NodeUIMapper.LoadXML(officialPositionList.List[i].GradeNodeUI, UINode, colorList);
            i++;
        }
    }
}
