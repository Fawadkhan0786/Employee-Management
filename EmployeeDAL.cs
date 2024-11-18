using System;

public class EmployeeDAL
{
	private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ConnectionString;

	public void AddEmployee(string name, string position, string department, decimal salary)
	{
		using (SqlConnection con = new SqlConnection(connectionString))
		{
			SqlCommand cmd = new SqlCommand("SpAddEmployee", con);
			cmd.CommandType = CommandType.StoreProcedure;
			cmd.Parameters.AddWithValue("@Name", name);
			cmd.Parameters.AddWithValue("@Position", position);
			cmd.Parameters.AddWithValue("@Department", department);
			cmd.Parameters.AddWithValue("@Salary", salary);
			con.Open();
			cmd.ExecuteNonQuery();

		}
	}
	public DataTable GetEmployees()
	{
		using (SqlConnection con = new SqlConnection(connectionString))
		{
			SqlCommand cmd = new SqlCommand("spGetEmployees", con)
			{
				cmd.CommandType = CommandType.StoredProcedure;
			    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			    DataTable dt = new DataTable();
			    adapter.Fill(dt);
			    return dt;
			}
		}
	}
}
}
