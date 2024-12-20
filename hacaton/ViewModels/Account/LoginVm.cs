﻿using System.ComponentModel.DataAnnotations;

namespace hacaton.ViewModels.Account
{
	public class LoginVm
	{
		[Required]
		public string UsernameOrEmail { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
