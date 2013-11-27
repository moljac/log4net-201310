#region Apache License
//
// Licensed to the Apache Software Foundation (ASF) under one or more 
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership. 
// The ASF licenses this file to you under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with 
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Collections;
using System.IO;

using log4net.Core;
using log4net.Layout.Pattern;
using log4net.Util;
using log4net.Util.PatternStringConverters;
using AppDomainPatternConverter=log4net.Layout.Pattern.AppDomainPatternConverter;
using DatePatternConverter=log4net.Layout.Pattern.DatePatternConverter;
using IdentityPatternConverter=log4net.Layout.Pattern.IdentityPatternConverter;
using PropertyPatternConverter=log4net.Layout.Pattern.PropertyPatternConverter;
using UserNamePatternConverter=log4net.Layout.Pattern.UserNamePatternConverter;
using UtcDatePatternConverter=log4net.Layout.Pattern.UtcDatePatternConverter;

namespace log4net.Layout
{
	public partial class PatternLayout 
	{
		private static void PatternLayoutAspNet()
		{
			s_globalRulesRegistry.Add("aspnet-cache", typeof(AspNetCachePatternConverter));
			s_globalRulesRegistry.Add("aspnet-context", typeof(AspNetContextPatternConverter));
			s_globalRulesRegistry.Add("aspnet-request", typeof(AspNetRequestPatternConverter));
			s_globalRulesRegistry.Add("aspnet-session", typeof(AspNetSessionPatternConverter));
		}
	}
}