using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maya.Controllers
{
	public class TestController : Controller
	{
		[HttpGet("api/v1/user")]
		public IActionResult Get()
		{
			return Ok(new {name = "firstname Lastname"});
		}
	}
}
