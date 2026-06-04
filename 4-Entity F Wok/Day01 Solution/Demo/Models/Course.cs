using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
	internal class Course
	{
		public int Id { get; set; }
		public string Tittle { get; set; } = null!;

		// Many [Navigation Property]
		//public ICollection<Student> Students { get; set; } = new HashSet<Student>();

		public ICollection<StudentCourses> CourseStudents { get; set; } = new HashSet<StudentCourses>();
	}
}
