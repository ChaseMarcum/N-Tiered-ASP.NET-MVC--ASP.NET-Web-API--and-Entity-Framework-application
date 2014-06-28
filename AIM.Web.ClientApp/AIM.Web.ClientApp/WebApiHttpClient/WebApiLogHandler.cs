using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;

namespace ASystems.WebApiHttpClient
{
	public class WebApiLogHandler : DelegatingHandler
	{
		protected readonly ILog Log = LogManager.GetLogger(typeof (WebApiLogHandler));

		public WebApiLogHandler()
			: this(new HttpClientHandler())
		{
		}

		public WebApiLogHandler(HttpMessageHandler innerHandler)
			: base(innerHandler)
		{
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			await TraceRequest(request);

			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

			await TraceResponse(response);

			return response;
		}

		private async Task TraceRequest(HttpRequestMessage request)
		{
			Log.Debug(string.Format("Request: {0} {1}", request.Method, request.RequestUri == (Uri) null ? "<null>" : request.RequestUri.ToString()));
			foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
			{
				foreach (var value in header.Value)
				{
					Log.Debug(string.Format("Request header: {{ {0} : {1} }}", header.Key, value));
				}
			}
			if (request.Content != null)
			{
				foreach (KeyValuePair<string, IEnumerable<string>> header in request.Content.Headers)
				{
					foreach (var value in header.Value)
					{
						Log.Debug(string.Format("Request header: {{ {0} : {1} }}", header.Key, value));
					}
				}
				Log.Debug("Request body: " + await request.Content.ReadAsStringAsync());
			}
		}

		private async Task TraceResponse(HttpResponseMessage response)
		{
			Log.Debug(string.Format("Response: {0} {1}", (int) response.StatusCode, response.ReasonPhrase ?? "<null>"));
			foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
			{
				foreach (var value in header.Value)
				{
					Log.Debug(string.Format("Response header: {{ {0} : {1} }}", header.Key, value));
				}
			}
			if (response.Content != null)
			{
				foreach (KeyValuePair<string, IEnumerable<string>> header in response.Content.Headers)
				{
					foreach (var value in header.Value)
					{
						Log.Debug(string.Format("Response header: {{ {0} : {1} }}", header.Key, value));
					}
				}
				Log.Debug("Response body: " + await response.Content.ReadAsStringAsync());
			}
		}
	}
}