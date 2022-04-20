using System;

namespace TestAutomationCourse.Demos.d00.Coverage
{
    internal class CreditCard
    {
		private DateTime expirationDate;
		public CreditCard(DateTime expirationDate)
		{
			this.expirationDate = expirationDate;
		}

		public bool IsExpired()
		{
			DateTime localExpDate = expirationDate.ToLocalTime();
			DateTime today = DateTime.Today.ToLocalTime();
			if (DateTime.Compare(localExpDate, today) > 0)
				return true;
			else
				return false;
		}
	}
}
