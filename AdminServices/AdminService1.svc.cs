using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace AdminServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService1.svc or AdminService1.svc.cs at the Solution Explorer and start debugging.
    public class AdminService1 : IAdminService1
    {
       public Boolean AdminSignIn(String Username, String Password)
        {
            SqlConnection conn = new SqlConnection("Data Source=MO3TA-LAPTOP;Initial Catalog=E-learning;Integrated Security=True");
            conn.Open();
            string retrievedUsername = "";
            string retrievedPassword = "";
            string sql = "SELECT AdminUsername, AdminPassword FROM Admin";

            // Create SqlCommand
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Execute SQL query and read results
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if there are rows returned
                    if (reader.Read())
                    {
                        // Assign retrieved values to variables
                        retrievedUsername = reader.GetString(0);
                        retrievedPassword = reader.GetString(1);
                    }
                }
            }
            if (retrievedUsername == Username && retrievedPassword == Password)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }


        public List<Course> ViewCourses()
        {
            // Create a list to store Course objects
            List<Course> courses = new List<Course>();

            // Connection string to your SQL Server
            string connectionString = "Data Source=MO3TA-LAPTOP;Initial Catalog=E-learning;Integrated Security=True";

            // Establish connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // SQL command to select all columns from Courses table
                string sql = "SELECT * FROM Courses";

                // Create SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Execute SQL query and read results
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Loop through the results
                        while (reader.Read())
                        {
                            // Create a new Course object and populate it with data from the reader
                            Course course = new Course();
                            course.CourseID = reader.GetInt32(reader.GetOrdinal("CourseID"));
                            course.CourseName = reader.GetString(reader.GetOrdinal("CourseName"));
                            course.CourseDescription = reader.GetString(reader.GetOrdinal("CourseDescription"));
                            course.CoursePrice = reader.GetInt32(reader.GetOrdinal("CoursePrice"));
                            course.CourseCategory = reader.GetString(reader.GetOrdinal("CourseCategory"));

                            // Add the Course object to the list
                            courses.Add(course);
                        }
                    }
                }
            }

            // Return the list of courses
            return courses;
        }

        public void AddCourse(string courseName, string courseDescription, int coursePrice, string courseCategory)
        {
            // Connection string to your SQL Server
            string connectionString = "Data Source=MO3TA-LAPTOP;Initial Catalog=E-learning;Integrated Security=True";

            // SQL command to insert a new course into the Courses table
            string sql = "INSERT INTO Courses (CourseName, CourseDescription, CoursePrice, CourseCategory) VALUES (@CourseName, @CourseDescription, @CoursePrice, @CourseCategory)";

            // Establish connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Add parameters for the new course
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@CourseDescription", courseDescription);
                    cmd.Parameters.AddWithValue("@CoursePrice", coursePrice);
                    cmd.Parameters.AddWithValue("@CourseCategory", courseCategory);

                    // Execute the SQL command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditCourse(int courseId, string courseName, string courseDescription, int coursePrice, string courseCategory)
        {
            // Connection string to your SQL Server
            string connectionString = "Data Source=MO3TA-LAPTOP;Initial Catalog=E-learning;Integrated Security=True";

            // SQL command to update an existing course in the Courses table
            string sql = "UPDATE Courses SET CourseName = @CourseName, CourseDescription = @CourseDescription, CoursePrice = @CoursePrice, CourseCategory = @CourseCategory WHERE CourseID = @CourseID";

            // Establish connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Add parameters for the updated course
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@CourseDescription", courseDescription);
                    cmd.Parameters.AddWithValue("@CoursePrice", coursePrice);
                    cmd.Parameters.AddWithValue("@CourseCategory", courseCategory);

                    // Execute the SQL command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCourse(int courseId)
        {
            // Connection string to your SQL Server
            string connectionString = "Data Source=MO3TA-LAPTOP;Initial Catalog=E-learning;Integrated Security=True";

            // SQL command to delete a course from the Courses table
            string sql = "DELETE FROM Courses WHERE CourseID = @CourseID";

            // Establish connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Create SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Add parameter for the course to be deleted
                    cmd.Parameters.AddWithValue("@CourseID", courseId);

                    // Execute the SQL command
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }

}
    

