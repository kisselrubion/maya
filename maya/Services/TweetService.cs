using System;
using System.Collections.Generic;
using System.Linq;
using maya.Domain;

namespace maya.Services
{
	public class TweetService : ITweetService
	{

		private readonly List<Tweet> _tweets;

		public TweetService()
		{
			_tweets = new List<Tweet>();
			//mock initial tweets
			for (int i = 0; i < 5; i++)
			{
				_tweets.Add(new Tweet
				{
					Id = Guid.NewGuid(),
					Name = $"Tweet Name{i}"
				});
			}
		}

		public List<Tweet> GetTweets()
		{
			return _tweets;
		}

		public Tweet GetTweetById(Guid tweetId)
		{
			return _tweets.SingleOrDefault(c => c.Id == tweetId);
		}

		public bool UpdateTweet(Tweet tweetToUpdate)
		{
			var exists = GetTweetById(tweetToUpdate.Id) != null;
			if (!exists)
			{
				return false;
			}

			var index = _tweets.FindIndex(c => c.Id == tweetToUpdate.Id);
			_tweets[index] = tweetToUpdate;
			return true;
		}

		public bool DeleteTweet(Guid tweetId)
		{
			var tweet = GetTweetById(tweetId);
			if (tweet == null)
			{
				return false;
			}
			_tweets.Remove(tweet);
			return true;
		}
	}
}