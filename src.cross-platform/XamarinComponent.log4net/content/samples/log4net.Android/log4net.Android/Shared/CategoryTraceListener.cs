namespace log4net.Tests.Appender
{
	public class CategoryTraceListener : System.Diagnostics.TraceListener
	{
		private string lastCategory;

		public override void Write(string message)
		{
			// empty
		}

		public override void WriteLine(string message)
		{
			Write(message);
		}

		public override void Write(string message, string category)
		{
			lastCategory = category;
			base.Write(message, category);
		}

		public string Category
		{
			get { return lastCategory; }
		}
	}
}