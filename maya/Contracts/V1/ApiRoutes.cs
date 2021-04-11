namespace maya.Contracts.V1
{
	public static class ApiRoutes
	{
		//swagger UI
		//https://localhost:5001/swagger/index.html

		public const string Version = "v1";
		public const string Root = "api";
		public const string Base = Root + " " + Version;

		public static class Tweets
		{
			public const string GetAll = Base + "/tweets";
			public const string Update = Base + "/tweets/{tweetId}";
			public const string Delete = Base + "/tweets/{tweetId}";
			public const string Get = Base + "/tweets/{tweetId}";
			public const string Create = Base + "/tweets";
		}

	}
}