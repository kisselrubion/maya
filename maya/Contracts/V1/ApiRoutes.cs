namespace maya.Contracts.V1
{
	public static class ApiRoutes
	{

		public const string Version = "v1";
		public const string Root = "api";
		public const string Base = Root + " " + Version;

		public static class Tweets
		{
			public const string GetAll = Base + "/tweets";
		}

	}
}