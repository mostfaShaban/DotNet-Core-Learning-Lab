using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Operator_Overloading
{
	// View Model : Is A Class That Represent a Data That Will Be Render In View [HTML]
	internal class UserViewModel
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }

		public static explicit operator UserViewModel(User user)
		{
			string[]? names = user?.FullName?.Split(" ") ;
			return new UserViewModel()
			{
				Id = user?.Id ?? 0,
				Email = user?.Email ?? string.Empty,
				FirstName = names?[0] ?? string.Empty,
				LastName = names?[1] ?? string.Empty,
			};
		}
	}
}
