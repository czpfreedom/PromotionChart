using Godot;
using System;

public partial class ChartSceneNode : Node2D
{
    [Export]
    public PackedScene OfficialPositionScene;

    [Export]
    public PackedScene DepartmentPositionScene;

    [Export]
    public PackedScene GraveScene;

    public DepartmentNode[] departmentNode;

    public OfficialPositionNode[] officialPositionNode;

    public GraveNode[] graveNode;

    public ColorList colorList;

    public DepartmentList departmentList;

    public OfficialPositionList officialPositionList;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        colorList = new ColorList();
        ColorListMapper.LoadXML(colorList, "D:/godot/PromotionChart/resources/Color.xml");

        departmentList =new();
        DepartmentMapper.LoadXML(departmentList, "D:/godot/PromotionChart/resources/Department.xml", colorList);
        SetDepertment(departmentList);

        officialPositionList = new OfficialPositionList();
        OfficialPositionMapper.LoadXML(departmentList, officialPositionList, "D:/godot/PromotionChart/resources/OfficialPosition.xml", colorList);
        GD.Print(1);
        GD.Print(officialPositionList.List[1].Name );
        //GD.Print((officialPositionList.List[1].Name=="BaiDing"));
        SetOfficialPosition(officialPositionList);
        SetGrave(officialPositionList);

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public void SetDepertment(DepartmentList departmentList) {
        departmentNode = new DepartmentNode[departmentList.Num];
        for (int i = 0; i < departmentList.Num; i++) {
            departmentNode[i] =(DepartmentNode)DepartmentPositionScene.Instantiate();
            departmentNode[i].Name = "Department"+i.ToString();
            departmentNode[i].Set(departmentList.List[i].NodeUI);
            departmentNode[i].Department = departmentList.List[i];
            AddChild(departmentNode[i]);
            //departmentNode[i].Owner = this;
        }
    }

    public void SetOfficialPosition(OfficialPositionList officialPositionList) {
        officialPositionNode = new OfficialPositionNode[officialPositionList.List.Count];
        for (int i = 0; i < officialPositionList.List.Count; i++) {
            officialPositionNode[i] = (OfficialPositionNode)OfficialPositionScene.Instantiate();
            officialPositionNode[i].Name = "OfficialPosition" +i.ToString();
            officialPositionNode[i].Set(officialPositionList.List[i].PositionNodeUI);
            officialPositionNode[i].OfficialPosition = officialPositionList.List[i];
            AddChild(officialPositionNode[i]);
        }
    }
    public void SetGrave(OfficialPositionList officialPositionList) {
        graveNode = new GraveNode[officialPositionList.List.Count];
        for (int i = 0;i < officialPositionList.List.Count;i++)
        {
            graveNode[i]=(GraveNode)GraveScene.Instantiate();
            graveNode[i].Name = "Grave"+i.ToString();
            graveNode[i].Set(officialPositionList.List[i].GradeNodeUI);
            AddChild(graveNode[i]);
        }
    }
}
