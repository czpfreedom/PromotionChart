using Godot;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


public class DepartmentMapper 
{
    public static void LoadXML(DepartmentList departmentList, string xmlName, ColorList colorList)
    {
        XmlDocument xml = new();
        xml.Load(xmlName);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("root").SelectNodes("department");
        int i = 0;
        Department department ;
        departmentList.List = new List<Department>();
        foreach (XmlNode departmentNode in xmlNodeList)
        {
            department = new Department();
            department.Name = departmentNode.SelectSingleNode("name").InnerText;
            department.ChineseName = departmentNode.SelectSingleNode("chinesename").InnerText;
            XmlNode uINode = departmentNode.SelectSingleNode("UI");
            NodeUIMapper.LoadXML(department.NodeUI, uINode, colorList); 
            departmentList.List.Add(department);
            i++;
        }
        departmentList.Num = i;

    }
}
