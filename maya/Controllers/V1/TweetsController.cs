using System;
using System.Collections.Generic;
using System.Linq;
using maya.Contracts;
using maya.Contracts.V1;
using maya.Contracts.V1.Requests;
using maya.Domain;
using maya.Services;
using Microsoft.AspNetCore.Mvc;

namespace maya.Controllers.V1
{
	public class TweetsController :Controller
	{
		private readonly ITweetService _tweetService;
		public TweetsController(ITweetService tweetService)
		{
			_tweetService = tweetService;
		}

		[HttpGet(ApiRoutes.Tweets.GetAll)]
		public IActionResult GetAll()
		{
			return Ok(_tweetService.GetTweets());
		}

		[HttpPut(ApiRoutes.Tweets.Update)]
		public IActionResult Update([FromRoute] Guid tweetId,[FromBody] UpdatePostRequest request)
		{
			var tweet = new Tweet
			{
				Id = tweetId,
				Name = request.Name
			};
			var updated = _tweetService.UpdateTweet(tweet);
			if (updated)
				return Ok(tweet);

			return NotFound();
		}

		[HttpDelete(ApiRoutes.Tweets.Delete)]
		public IActionResult Delete([FromRoute] Guid tweetId)
		{
			var deleted = _tweetService.DeleteTweet(tweetId);
			if (deleted)
				return NoContent();
			return NotFound();
		}


		[HttpGet(ApiRoutes.Tweets.Get)]
		public IActionResult Get([FromRoute] Guid tweetId)
		{
			var tweet = _tweetService.GetTweetById(tweetId);

			if (tweet == null) 
				return NotFound();

			return Ok(tweet);
		}

		[HttpPost(ApiRoutes.Tweets.Create)]
		public IActionResult Create([FromBody] CreatePostRequest tweetRequest)
		{
			var tweet = new Tweet {Id = tweetRequest.Id};
			if (tweet.Id != Guid.Empty)
				tweet.Id = Guid.NewGuid();

			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
			var locationUri = baseUrl + "/" + ApiRoutes.Tweets.Get.Replace("{tweetId}", tweet.ToString());

			var response = new PostResponse {Id = tweet.Id};
			return Created(locationUri,response);
		}
	}
}