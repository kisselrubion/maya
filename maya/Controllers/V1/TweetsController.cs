using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maya.Contracts;
using maya.Contracts.V1;
using maya.Contracts.V1.Requests;
using maya.Domain;
using maya.Services;
using Microsoft.AspNetCore.Mvc;

namespace maya.Controllers.V1
{
	public class TweetsController : Controller
	{
		private readonly ITweetService _tweetService;

		public TweetsController(ITweetService tweetService)
		{
			_tweetService = tweetService;
		}

		[HttpGet(ApiRoutes.Tweets.GetAll)]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _tweetService.GetTweetsAsync());
		}

		[HttpPut(ApiRoutes.Tweets.Update)]
		public async Task<IActionResult> Update([FromRoute] Guid tweetId, [FromBody] UpdatePostRequest request)
		{
			var tweet = new Tweet
			{
				Id = tweetId,
				Name = request.Name
			};
			var updated = await _tweetService.UpdateTweetAsync(tweet);
			if (updated)
				return Ok(tweet);

			return NotFound();
		}

		[HttpDelete(ApiRoutes.Tweets.Delete)]
		public async Task<IActionResult> Delete([FromRoute] Guid tweetId)
		{
			var deleted = await _tweetService.DeleteTweetAsync(tweetId);
			if (deleted)
				return NoContent();
			return NotFound();
		}


		[HttpGet(ApiRoutes.Tweets.Get)]
		public async Task<IActionResult> Get([FromRoute] Guid tweetId)
		{
			var tweet = await _tweetService.GetTweetByIdAsync(tweetId);

			if (tweet == null)
				return NotFound();

			return Ok(tweet);
		}

		[HttpPost(ApiRoutes.Tweets.Create)]
		public async Task<IActionResult> Create([FromBody] CreatePostRequest tweetRequest)
		{
			var tweet = new Tweet
			{
				Name = tweetRequest.Name,
			};

			await _tweetService.CreateTweetAsync(tweet);
			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
			var locationUri = baseUrl + "/" + ApiRoutes.Tweets.Get.Replace("{tweetId}", tweet.Id.ToString());

			var response = new PostResponse{ Id = tweet.Id};
			return Created(locationUri, response);
		}
	}
}