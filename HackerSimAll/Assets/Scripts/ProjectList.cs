using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class ProjectList
{
    private List<Project> projectList;

    public ProjectList()
    {
        projectList = new List<Project>();
    }
    
    public List<Project> GetProjects()
    { return projectList; }

    public Project GetProject(int id)
    {
        foreach (Project item in projectList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        throw new System.InvalidOperationException("This project does not exist");
    }

    public void hourPass()
    {
        foreach (Project item in projectList)
        {
            item.deadlineMinusOne();

        }
    }

    public int minutePass(int workingOn)
    {
        
        foreach (Project item in projectList)
        {
            if (item.ID == workingOn)
            {
                item.comptimeMinusOne();
                item.resetDesc();
                return item.compTime;
            }
        }
        throw new System.InvalidOperationException("Project" + workingOn +  " does not exist. Can't pass minute");
    }

    public void AddProject(Project newProject)
    {
        //if (newProject == null)
        //{
            //throw new System.ArgumentNullException(nameof(newProject));
        //}

        projectList.Add(newProject);
    }

    public void RemoveProjects(int id)
    {
        if (id == null)
        {
            throw new System.ArgumentNullException(nameof(id));
        }
        foreach(Project item in projectList)
        {
            if (item.ID == id)
            {
                projectList.Remove(item);
                break;
            }
        }
    }

    public string getProjectInfo(int id)
    {
        if (id == null)
        {
            throw new System.ArgumentNullException(nameof(id));
        }
        foreach (Project item in projectList)
        {
            if (item.ID == id)
            {
                    return item.Desc;
            }
        }
        throw new System.InvalidOperationException("This project does not exist");
    }
}
