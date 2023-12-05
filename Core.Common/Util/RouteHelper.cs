namespace Core.Common.Util;

public class RouteHelper
{
	public class Transaction
	{
		public const string GetList = "transaction_get_list";

		public const string GetPage = "transaction_get_page";

		public const string GetById = "transaction_get_by_id";

		public const string GetStatistics = "transaction_get_statistics";

		public const string GetSummary = "transaction_get_summary";

		public const string Save = "transaction_save";

		public const string Delete = "transaction_delete";
	}

	public class StaticData
	{
		public const string GetCategoryList = "category_get_list";

		public const string GetCategoryPage = "category_get_page";

		public const string GetCategoryById = "category_get_by_id";

		public const string SaveCategory = "category_save";

		public const string DeleteCategory = "category_delete";


		public const string GetCardList = "card_get_list";

		public const string GetCardPage = "card_get_page";

		public const string GetCardById = "card_get_by_id";

		public const string SaveCard = "card_save";

		public const string DeleteCard = "card_delete";


		public const string GetAccountList = "account_get_list";

		public const string GetAccountPage = "account_get_page";

		public const string GetAccountById = "account_get_by_id";

		public const string SaveAccount = "account_save";

		public const string DeleteAccount = "account_delete";
	}
}
