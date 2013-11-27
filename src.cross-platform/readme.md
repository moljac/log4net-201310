# log4net cross-platform port

## Steps

1. split lo4net into  
	1.  client profile based assembly (desktop - and preparation for mobile)	
	1.	ASP.net assembly	
1	files in ASP.net 	
	1.	SmtpAppender.cs	
	1.	Layout\Pattern		
		1.	AspNetCachePatternConverter.cs	
		1.	AspNetContextPatternConverter.cs	
		1.	AspNetPatternConverter.cs	
		1.	AspNetRequestPatternConverter.cs	
		1.	AspNetSessionPatternConverter.cs	
1.  partialized and extracted/splitted classes
	1.	PatternLayout
	1.	
1. 	unit tests		
	NOTE: the same results as in original code!!!
	1. failed	
		1.	RemotingAppenderTest
		1.	DynamicPatternlayoutTest
		1.	PatternLayoutTest
	1.	skipped
		1.	SystemLevelEnvironmentVariable - IgnoreException (SecurityException)
		1.	RollingFileAppenderTest -some init tests
			1.	TestInitialization3		
			1.	TestInitialization4		
			1.	TestInitialization5		
			1.	TestInitialization6		
			1.	TestInitialization7		
			
## References/Links

*	[https://issues.apache.org/jira/browse/LOG4NET-338](https://issues.apache.org/jira/browse/LOG4NET-338)	
*	[http://mono-for-android.1047100.n5.nabble.com/Problems-with-log4net-td4641046.html](http://mono-for-android.1047100.n5.nabble.com/Problems-with-log4net-td4641046.html)	
*	[http://stackoverflow.com/questions/9677789/log4net-for-monotouch](http://stackoverflow.com/questions/9677789/log4net-for-monotouch)	
*	[http://stackoverflow.com/questions/17439428/log4net-works-with-xamarin-ios-monotouch](http://stackoverflow.com/questions/17439428/log4net-works-with-xamarin-ios-monotouch)	
*	[]()	
*	[]()	
			
			
### netfx 4 Security Exceptions 
			
*	[http://stackoverflow.com/questions/2903669/log4net-and-net-framework-4-0](http://stackoverflow.com/questions/2903669/log4net-and-net-framework-4-0)	
*	[]()	
*	[]()	
			
			
## Port to Mono mobile (Xamarin.*) profile 2013-09

### Xamarin.Android

#### Errors

19:

1.	Error	24			
	The type or namespace name 'RenamedEventArgs' could not be found
	(are you missing a using directive or an assembly reference?)	
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Config\XmlConfigurator.cs	
	1025	67	log4net.XamarinAndroid.vs2010
1.	Error	15	
	The type or namespace name 'IDbTransaction' could not be found
	(are you missing a using directive or an assembly reference?)	
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs	
	541	37	log4net.XamarinAndroid.vs2010
1.	Error	11		
	The type or namespace name 'IDbConnection' could not be found 	
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	377	13	log4net.XamarinAndroid.vs2010
1.	Error	18		
	The type or namespace name 'IDbConnection' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	628	27	log4net.XamarinAndroid.vs2010
1.	Error	19		
	The type or namespace name 'IDbConnection' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	901	11	log4net.XamarinAndroid.vs2010
1.	Error	20		
	The type or namespace name 'IDbCommand' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	906	11	log4net.XamarinAndroid.vs2010
1.	Error	27		
	The type or namespace name 'IDbCommand' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	1156	31	log4net.XamarinAndroid.vs2010
1.	Error	28		
	The type or namespace name 'IDbCommand' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	1196	35	log4net.XamarinAndroid.vs2010
1.	Error	2		
	The type or namespace name 'IConfigurationSectionHandler' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Config\Log4NetConfigurationSectionHandler.cs		
	51	52	log4net.XamarinAndroid.vs2010
1.	Error	22		
	The type or namespace name 'FileSystemWatcher' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Config\XmlConfigurator.cs		
	953	21	log4net.XamarinAndroid.vs2010
1.	Error	23		
	The type or namespace name 'FileSystemEventArgs' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Config\XmlConfigurator.cs		
	1006	67	log4net.XamarinAndroid.vs2010
1.	Error	14		
	The type or namespace name 'EventLogEntryType' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\EventLogAppender.cs		
	505	21	log4net.XamarinAndroid.vs2010
1.	Error	16		
	The type or namespace name 'EventLogEntryType' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\EventLogAppender.cs		
	586	12	log4net.XamarinAndroid.vs2010
1.	Error	17		
	The type or namespace name 'EventLogEntryType' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\EventLogAppender.cs		
	597	11	log4net.XamarinAndroid.vs2010
1.	Error	26		
	The type or namespace name 'DbType' could not be found 		
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	1037	10	log4net.XamarinAndroid.vs2010
1.	Error	1		
	The type or namespace name 'Data' does not exist in the namespace 'System' 
	(are you missing an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	26	14	log4net.XamarinAndroid.vs2010
1.	Error	8		
	The type or namespace name 'CommandType' could not be found 	
	(are you missing a using directive or an assembly reference?)		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	280	10	log4net.XamarinAndroid.vs2010
1.	Error	29			
	'log4net.Appender.AdoNetAppenderParameter.DbType' is a 'property' but is used like a 'type'		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	1225	11	log4net.XamarinAndroid.vs2010
1.	Error	21	
	'log4net.Appender.AdoNetAppender.CommandType' is a 'property' but is used like a 'type'		
	\log4net\src.cross-platform\log4net.ClientProfile.vs2010\Appender\AdoNetAppender.cs		
	938	11	log4net.XamarinAndroid.vs2010

#### Solution/Workarounf

##### Removal of offending types

1.	RenamedEventArgs	
	1.	removed XmlConfiguration		
		hardly to be XmlConfig files	
		[]()		
	1.	removed link DOMConfigurator.cs
	1.	removed link XmlConfiguratorAttribute.cs
	1.	removed link DOMConfiguratorAttribute.cs
	1.	removed link DefaultRepositorySelector.cs
	1.	removed link LoggerManager
1.	IDbConnection	
	1.	removed link AdoNetAppender.cs		
1.	IDbCommand	
	1.	removed link AdoNetAppender.cs	
1.	IConfigurationSectionHandler	
	1.	removed Log4NetConfigurationSectionHandler.cs	
1. 	FileSystemWatcher	
1.	FileSystemEventArgs	
1.	EventLogEntryType	
1.	DbType	
1.	System.Data	
	1.	removed AdoNetAppender.cs		





##### Patching/Adding/Replacing offending types

TODO moljac++
