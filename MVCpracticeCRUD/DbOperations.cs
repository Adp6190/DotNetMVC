using Microsoft.Data.SqlClient;
using MVCpracticeCRUD.Models;
using System.Data;


namespace MVCpracticeCRUD
{
    public class DbOperations
    {

        public void InsertStudent(Student s)
        {
            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Insert into Student values(@Id,@Name,@Department)",cn);
            cn.Open();
            cmd.Parameters.AddWithValue("Id", s.Id);
            cmd.Parameters.AddWithValue("Name", s.Name);
            cmd.Parameters.AddWithValue("Department", s.Department);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void UpdateStudent(int Id, Student s)
        {
            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("UPDATE  Student set Name=@Name, Department=@Department where Id=" + Id, cn);
            cn.Open();
            cmd.Parameters.AddWithValue("Name", s.Name);
            cmd.Parameters.AddWithValue("Department", s.Department);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void DeleteStudent(int Id)
        {
            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Delete from Student where Id=" + Id, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public Student findStudent(int Id)
        {
            SqlConnection cn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DB1; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("select * from Student where Id=" + Id, cn);
            cn.Open();
            Student s = new Student();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s.Id = (int)dr[0];
                s.Name = (string)dr[1];
                s.Department = (string)dr[2];
            }
            cn.Close();
            cn.Dispose();
            return s;
        }

        public List<Student> GetAllStudents()
        {
            SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB1;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Student",cn);
            cn.Open();
            List<Student> stud = new List<Student>();
            SqlDataReader datareader = cmd.ExecuteReader();
            DataTable datatable = new DataTable();
            datatable.Load(datareader);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                Student s = new Student();
                s.Id = (int)datatable.Rows[i][0];
                s.Name = (string)datatable.Rows[i][1];
                s.Department = (string)datatable.Rows[i][2];
                stud.Add(s);
            }
            Console.WriteLine("List is");
            for (int i = 0; i < stud.Count; i++)
            {
                Console.WriteLine(stud[i].Id + " " + stud[i] + " " + stud[i].Department);
            }
            cn.Close();
            cn.Dispose();
            return stud;


        }
    }
}
