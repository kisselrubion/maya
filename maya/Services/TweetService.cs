using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maya.Data;
using maya.Domain;
using Microsoft.EntityFrameworkCore;

namespace maya.Services
{
	public class TweetService : ITweetService
	{
		private readonly DataContext _dataContext;

		public TweetService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<Tweet>> GetTweetsAsync()
		{
			return await _dataContext.Tweets.ToListAsync();
		}

		public async Task<Tweet> GetTweetByIdAsync(Guid tweetId)
		{
			return await _dataContext.Tweets.SingleOrDefaultAsync(c => c.Id == tweetId);
		}

		public async Task<bool> CreateTweetAsync(Tweet tweet)
		{
			await _dataContext.AddAsync(tweet);
			var created = await _dataContext.SaveChangesAsync();
			return created > 0;
		}
		public async Task<bool> UpdateTweetAsync(Tweet tweetToUpdate)
		{
			_dataContext.Tweets.Update(tweetToUpdate);
			var updated= await _dataContext.SaveChangesAsync();
			return updated > 0;
		}

		public async Task<bool> DeleteTweetAsync(Guid tweetId)
		{
			var tweet = await GetTweetByIdAsync(tweetId);
			if (tweet == null)
			{
				return false;
			}
			_dataContext.Tweets.Remove(tweet);
			var deleted = await _dataContext.SaveChangesAsync();
			return deleted > 0;
		}
	}
}