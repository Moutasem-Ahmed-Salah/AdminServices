using System;
using System.Runtime.Serialization;

namespace AdminServices
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public string CourseDescription { get; set; }

        [DataMember]
        public int CoursePrice { get; set; }

        [DataMember]
        public string CourseCategory { get; set; }
    }
}
