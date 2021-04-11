using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using maya.Domain;

namespace maya.Services
{
	public interface ITweetService
	{
		Task<List<Tweet>> GetTweetsAsync();
		Task<Tweet> GetTweetByIdAsync(Guid tweetId);
		Task<bool> CreateTweetAsync(Tweet tweet);
		Task<bool> UpdateTweetAsync(Tweet tweetToUpdate);
		Task<bool> DeleteTweetAsync(Guid tweetId);
	}
}