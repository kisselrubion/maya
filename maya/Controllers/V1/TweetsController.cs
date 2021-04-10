using System;
using System.Collections.Generic;
using maya.Contracts;
using maya.Contracts.V1;
using maya.Domain;
using Microsoft.AspNetCore.Mvc;

namespace maya.Controllers.V1
{
	public class TweetsController :Controller
	{
		private List<Tweet> _tweets;

		public TweetsController()
		{
			_tweets = new List<Tweet>();
			//mock initial tweets
			for (int i = 0; i < 5; i++)
			{
				_tweets.Add(new Tweet{ Id = Guid.NewGuid().ToString()});
			}
		}

		[HttpGet(ApiRoutes.Tweets.GetAll)]
		public IActionResult GetAll()
		{
			return Ok(_tweets);
		}
	}
}