using System;
using System.Configuration;

namespace StrongConfig.Example
{
	/// <summary>
	/// Provides strongly-typed access to configuration data.
	/// </summary>
	public class ConfigurationFacade
	{
		public virtual string webpagesVersion
		{
			get { return ConfigurationManager.AppSettings["webpages:Version"]; }
		}

		public virtual bool webpagesEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["webpages:Enabled"]); }
		}

		public virtual bool ClientValidationEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["ClientValidationEnabled"]); }
		}

		public virtual bool UnobtrusiveJavaScriptEnabled
		{
			get { return bool.Parse(ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]); }
		}
	}
}
