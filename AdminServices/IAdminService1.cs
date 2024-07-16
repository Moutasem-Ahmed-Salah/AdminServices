using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace AdminServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService1" in both code and config file together.
    [ServiceContract]
    public interface IAdminService1
    {
        [OperationContract]
        Boolean AdminSignIn(String Username,String Password);

        [OperationContract]
        void AddCourse(string courseName, string courseDescription, int coursePrice, string courseCategory);

        [OperationContract]
        void DeleteCourse(int courseId);
        [OperationContract]
        void EditCourse(int courseId, string courseName, string courseDescription, int coursePrice, string courseCategory);

        [OperationContract]
        List<Course> ViewCourses();
      
    }
}
