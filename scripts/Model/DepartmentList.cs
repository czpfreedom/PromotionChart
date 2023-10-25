using System.Collections;
using System.Collections.Generic;
using System;


public class DepartmentList 
{
    int num;

    List<Department> list;

    public int Num { get => num; set => num = value; }
    public List<Department> List { get => list; set => list = value; }

    public Department FindDepartmentByName(string name) {
        for (int indexer = 0; indexer < num; indexer++) {
            if (list[indexer].Name == name) { 
                return list[indexer];
            }
        }
        return null;
    }
}
