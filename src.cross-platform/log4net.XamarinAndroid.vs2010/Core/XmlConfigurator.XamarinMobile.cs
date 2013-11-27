using System;
using System.Xml;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Net;

using log4net.Appender;
using log4net.Util;
using log4net.Repository;

namespace log4net.Config
{
	public sealed partial class XmlConfigurator
	{
		internal static void ConfigureAndWatch(ILoggerRepository repository, FileInfo repositoryConfigFileInfo)
		{
			throw new NotImplementedException();
		}

		internal static void Configure(ILoggerRepository repository, Uri repositoryConfigUri)
		{
			throw new NotImplementedException();
		}
	}
}