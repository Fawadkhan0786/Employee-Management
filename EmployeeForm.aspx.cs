using System;
using System.Data;
using System.Xml.Linq;
using System.Web.UI;
namespace EmployeeManagement
{

    public partial class EmployeeForm : System.Web.UI.Page
    {
        // Create an instance of EmployeeDAL to access the database
        private EmployeeDAL employeeDAL = new EmployeeDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load employees into GridView when the page first loads
                LoadEmployees();
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Retrieve data from input fields
            string name = txtName.Text;
            string position = txtPosition.Text;
            string department = txtDepartment.Text;
            decimal salary;

            // Validate salary input
            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                // Handle invalid salary input
                Response.Write("<script>alert('Please enter a valid salary.');</script>");
                return;
            }

            // Call the data access layer to add the employee
            employeeDAL.AddEmployee(name, position, department, salary);

            // Refresh the GridView
            LoadEmployees();

            // Clear input fields
            ClearFields();
        }

        private void LoadEmployees()
        {
            // Get employee data from the database
            DataTable dt = employeeDAL.GetEmployees();

            // Bind the data to the GridView
            GridViewEmployees.DataSource = dt;
            GridViewEmployees.DataBind();
        }

        private void ClearFields()
        {
            // Clear all input fields
            txtName.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtDepartment.Text = string.Empty;
            txtSalary.Text = string.Empty;
        }
    }
}

