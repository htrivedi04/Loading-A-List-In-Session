using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRModule;
using System.Data;

public partial class TestProj_SessionList : System.Web.UI.Page
{
    TestProjClass objTest = new TestProjClass();
    DataTable dt = new DataTable();
    List<Employees> EmpList = new List<Employees>();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetEmployeeList();
        //PrintEmpList();
        LoadSession();
        LoadSortedList();
    }

    protected void GetEmployeeList() 
    {
        dt = objTest.GetEmployees();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Employees objEmp = new Employees(Convert.ToString(dt.Rows[i]["EMP_NAME_P"]), Convert.ToString(dt.Rows[i]["EMP_HAY_DES"]), Convert.ToString(dt.Rows[i]["EMP_DEPT"]));
            EmpList.Add(objEmp);
        }
    }

    protected void PrintEmpList()
    {
        foreach (var Employee in EmpList)
        {
            Label1.Text += Employee.EmpName + " | " + Employee.EmpDesg + " | " + Employee.EmpDept + "<br/>";            
        }
    }

    protected void LoadSession()
    {
        Session["Employees"] = EmpList;
    }

    protected void LoadSortedList()
    {
        List<Employees> SortedList = new List<Employees>();
        SortedList = (List<Employees>)(Session["Employees"]);
        foreach (var Employee in SortedList)
        {
            if (Employee.EmpDept == "ELECTRICAL")
            {
                Label1.Text += Employee.EmpName + "  |  " + Employee.EmpDesg + "  |  " + Employee.EmpDept + "<br/>";
            }
        }
    }
}