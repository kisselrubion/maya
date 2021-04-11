using System;
using System.Collections.Generic;
using maya.Domain;

namespace maya.Services
{
	public interface ITweetService
	{
		List<Tweet> GetTweets();
		Tweet GetTweetById(Guid tweetId);
		bool UpdateTweet(Tweet tweetToUpdate);
		bool DeleteTweet(Guid tweetId);
	}
}