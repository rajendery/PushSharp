using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PushSharp.Core;

namespace PushSharp.Android
{
	public class GcmPushChannelSettings : IPushChannelSettings
	{
		private const string GCM_SEND_URL = "https://android.googleapis.com/gcm/send";
		WebProxy obj=new WebProxy("proxy.cognizant.com:6050",true);
		WebRequest rqst=WebRequest.Create(GCM_SEND_URL);
		rqst.Proxy=obj;
 
		public GcmPushChannelSettings(string senderAuthToken)
		{
			this.SenderAuthToken = senderAuthToken;
			this.GcmUrl = GCM_SEND_URL;

            this.ValidateServerCertificate = false;
        }

		public GcmPushChannelSettings(string optionalSenderID, string senderAuthToken, string optionalApplicationIdPackageName)
		{
			this.SenderID = optionalSenderID;
			this.SenderAuthToken = senderAuthToken;
			this.ApplicationIdPackageName = optionalApplicationIdPackageName;
			this.GcmUrl = GCM_SEND_URL;

            this.ValidateServerCertificate = false;
        }

		public string SenderID { get; private set; }
		public string SenderAuthToken { get; private set; }
		public string ApplicationIdPackageName { get; private set; }

        public bool ValidateServerCertificate { get; set; }

		public string GcmUrl { get; set; }

		public void OverrideUrl(string url)
		{
			GcmUrl = url;
		}
	}
}
