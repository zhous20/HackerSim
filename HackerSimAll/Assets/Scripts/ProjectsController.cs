using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


public class ProjectsController : MonoBehaviour
{
    private string PROJECT_DATA_PATH = "/Projects.a";
    private int initialized = 0;
    public int workingOn = 0;
    private float hourCount = 3600;
    private float[] minuteCount = new float[] { 1, 1, 1, 1, 1 };
    //private float[] minuteCount = new float[] { 60, 60, 60, 60, 60 };
    public ProjectList projects;

    // Start is called before the first frame update
    void Start()
    {

        workingOn = PlayerPrefs.GetInt("currently_working_on", 0);
        setSceneActive(0);

        initialized = PlayerPrefs.GetInt("initializedProjects", 0);
        //print(initialized);
        hourCount = PlayerPrefs.GetFloat("second_left_hour", 3600);
        // minuteCount[0] = PlayerPrefs.GetFloat("second_left_minute_1", 60);
        // minuteCount[1] = PlayerPrefs.GetFloat("second_left_minute_2", 60);
        // minuteCount[2] = PlayerPrefs.GetFloat("second_left_minute_3", 60);
        // minuteCount[3] = PlayerPrefs.GetFloat("second_left_minute_4", 60);
        // minuteCount[4] = PlayerPrefs.GetFloat("second_left_minute_5", 60);
        minuteCount[0] = PlayerPrefs.GetFloat("second_left_minute_1", 1);
        minuteCount[1] = PlayerPrefs.GetFloat("second_left_minute_2", 1);
        minuteCount[2] = PlayerPrefs.GetFloat("second_left_minute_3", 1);
        minuteCount[3] = PlayerPrefs.GetFloat("second_left_minute_4", 1);
        minuteCount[4] = PlayerPrefs.GetFloat("second_left_minute_5", 1);
        if (initialized == 0)
        {
            initializeProjects();
            initialized = 1;
        }
        else
        {
            LoadProjectsData();
        }

        updateView();
    }

    // Update is called once per frame
    void Update()
    {
        updateView();
        hourCount -= Time.deltaTime;
        if (Mathf.Round(hourCount) == 0)
        {
            hourCount = 3600;
            projects.hourPass();
            List<Project> projectList = projects.GetProjects();
            foreach (Project item in projectList)
            {
                if (item.Deadline == 0)
                {
                    int id = item.ID;
                    projects.RemoveProjects(id);
                    Project newProject = generateNewProject(id);
                    projects.AddProject(newProject);
                }
            }
        }

        if (workingOn != 0)
        {

            minuteCount[workingOn - 1] -= Time.deltaTime;
            if(ChangeComputer.upgrade)
            {
              minuteCount[workingOn - 1] -= Time.deltaTime;
              UnityEngine.Debug.Log("computer change");
            }
            //print(minuteCount[workingOn - 1]);
            if (Mathf.Round(minuteCount[workingOn - 1]) == 0)
            {
                minuteCount[workingOn - 1] = 1;
                int minuteLeft = projects.minutePass(workingOn);
                //print(minuteLeft);
                if (minuteLeft == 0)
                {
                    Project compProject = projects.GetProject(workingOn);
                    compProject.Completion = true;
                    int awardCurrency = compProject.Currency;
                    int awardExp = compProject.Exp;

                    SEAttributes player = SaveSEAttributes.LoadPlayer();
                    SEAttributesController.AdjustCurrency(player, awardCurrency);

                    projects.RemoveProjects(workingOn);
                    Project newProject = generateNewProject(workingOn);
                    projects.AddProject(newProject);
                    int temp = workingOn;
                    stopProject();
                    setSceneActive(temp);
                    setPreviousSceneInactive(temp);

                }
            }

        }

    }

    Project generateNewProject(int id)
    {
        var randGen = new System.Random();
        int currency = randGen.Next(10, 60);
        int exp = randGen.Next(10, 60);
        Project newProject = new Project(id, currency, exp, 120);
        return newProject;
    }

    void updateView()
    {
        GameObject project1DescObj = GameObject.FindGameObjectWithTag("ProjectOneText");
        GameObject project2DescObj = GameObject.FindGameObjectWithTag("ProjectTwoText");
        GameObject project3DescObj = GameObject.FindGameObjectWithTag("ProjectThreeText");
        GameObject project4DescObj = GameObject.FindGameObjectWithTag("ProjectFourText");
        GameObject project5DescObj = GameObject.FindGameObjectWithTag("ProjectFiveText");

        TextMeshProUGUI project1Desc = project1DescObj.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI project2Desc = project2DescObj.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI project3Desc = project3DescObj.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI project4Desc = project4DescObj.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI project5Desc = project5DescObj.GetComponent<TextMeshProUGUI>();


        project1Desc.text = projects.getProjectInfo(1);
        project2Desc.text = projects.getProjectInfo(2);
        project3Desc.text = projects.getProjectInfo(3);
        project4Desc.text = projects.getProjectInfo(4);
        project5Desc.text = projects.getProjectInfo(5);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("currently_working_on", workingOn);
        PlayerPrefs.SetInt("initializedProjects", initialized);
        PlayerPrefs.SetFloat("second_left_hour", hourCount);
        PlayerPrefs.SetFloat("second_left_minute_1", minuteCount[0]);
        PlayerPrefs.SetFloat("second_left_minute_2", minuteCount[1]);
        PlayerPrefs.SetFloat("second_left_minute_3", minuteCount[2]);
        PlayerPrefs.SetFloat("second_left_minute_4", minuteCount[3]);
        PlayerPrefs.SetFloat("second_left_minute_5", minuteCount[4]);
        SaveProjectsData();
    }

    public void closeProjects()
    {
        SceneManager.LoadScene("GeneralRoom");
    }

    void initializeProjects()
    {
        projects = new ProjectList();
        Project project1 = new Project(1, 50, 50, 120);
        Project project2 = new Project(2, 10, 30, 120);
        Project project3 = new Project(3, 25, 40, 120);
        Project project4 = new Project(4, 30, 15, 120);
        Project project5 = new Project(5, 60, 45, 120);
        projects.AddProject(project1);
        projects.AddProject(project2);
        projects.AddProject(project3);
        projects.AddProject(project4);
        projects.AddProject(project5);

    }



    public void startProject()
    {
        GameObject initialState = GameObject.Find("Canvas/ProjectsViewInit");
        ToggleGroup proToggleGroup = initialState.GetComponent<ToggleGroup>();
        var projectToggles = proToggleGroup.GetComponentsInChildren<Toggle>();
        if (projectToggles[0].isOn)
        {
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart1");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
            workingOn = 1;
        }
        else if (projectToggles[1].isOn)
        {
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart2");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
            workingOn = 2;
        }
        else if (projectToggles[2].isOn)
        {
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart3");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
            workingOn = 3;
        }
        else if (projectToggles[3].isOn)
        {
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart4");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
            workingOn = 4;
        }
        else if (projectToggles[4].isOn)
        {
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart5");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
            workingOn = 5;
        }

    }

    void setSceneActive(int previous)
    {

        if(workingOn == 1)
        {
            GameObject initialState = GameObject.Find("Canvas/ProjectsViewInit");
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart1");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
        }
        else if (workingOn == 2)
        {
            GameObject initialState = GameObject.Find("Canvas/ProjectsViewInit");
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart2");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
        }
        else if (workingOn == 3)
        {
            GameObject initialState = GameObject.Find("Canvas/ProjectsViewInit");
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart3");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
        }
        else if (workingOn == 4)
        {
            GameObject initialState = GameObject.Find("Canvas/ProjectsViewInit");
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart4");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
        }
        else if (workingOn == 5)
        {
            GameObject initialState = GameObject.Find("Canvas/ProjectsViewInit");
            initialState.SetActive(false);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewStart5");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
        }
        else if(workingOn == 0 && previous != 0)
        {

            string temp = "Canvas/ProjectsViewStart" + previous;
            //print(temp);
            GameObject initialState = GameObject.Find(temp);
            //print(initialState == null);
            Transform startOneTrans = initialState.transform.parent.Find("ProjectsViewInit");
            GameObject startOne = startOneTrans.gameObject;
            startOne.SetActive(true);
        }
    }

    void setPreviousSceneInactive(int previous)
    {
        //print(previous);
        if (previous == 1)
        {
            GameObject currentState = GameObject.Find("Canvas/ProjectsViewStart1");
            currentState.SetActive(false);
        }
        else if (previous == 2)
        {
            GameObject currentState = GameObject.Find("Canvas/ProjectsViewStart2");
            currentState.SetActive(false);
        }
        else if (previous == 3)
        {
            GameObject currentState = GameObject.Find("Canvas/ProjectsViewStart3");
            currentState.SetActive(false);
        }
        else if (previous == 4)
        {
            GameObject currentState = GameObject.Find("Canvas/ProjectsViewStart4");
            currentState.SetActive(false);
        }
        else if (previous == 5)
        {
            GameObject currentState = GameObject.Find("Canvas/ProjectsViewStart5");
            currentState.SetActive(false);
        }
        else {  }
    }
    public void stopProject()
    {
        workingOn = 0;
    }

    void LoadProjectsData()
    {
        FileStream projectsFile = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            projectsFile = File.Open(Application.persistentDataPath + PROJECT_DATA_PATH, FileMode.Open);
            projects = bf.Deserialize(projectsFile) as ProjectList;

        }
        catch (Exception e)
        {
            if (e != null)
            {
                print(e);
            }
        }
        finally
        {
            if (projectsFile != null)
            {
                projectsFile.Close();
            }
        }

    }
    void SaveProjectsData()
    {
        FileStream projectsFile = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            projectsFile = File.Create(Application.persistentDataPath + PROJECT_DATA_PATH);
            bf.Serialize(projectsFile, projects);
        }catch(Exception e){
            if (e != null)
            {
                print(e);
            }
        }
        finally
        {
            if (projectsFile != null)
            {
                projectsFile.Close();
            }
        }
    }
}
