using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ASystems.WebApiHttpClient
{
	public class WebApiHttpClient : HttpClient
	{
		public WebApiHttpClient(string baseAddress = null)
			: this(new WebApiLogHandler(), baseAddress: baseAddress)
		{
		}

		public WebApiHttpClient(Uri baseAddress = null)
			: this(new WebApiLogHandler(), baseAddress: baseAddress)
		{
		}

		public WebApiHttpClient(HttpMessageHandler handler, bool disposeHandler = true, string baseAddress = null)
			: base(handler, disposeHandler)
		{
			if (!string.IsNullOrEmpty(baseAddress))
			{
				BaseAddress = CreateUri(baseAddress);
			}
		}

		public WebApiHttpClient(HttpMessageHandler handler, bool disposeHandler = true, Uri baseAddress = null)
			: base(handler, disposeHandler)
		{
			if (baseAddress != null)
			{
				BaseAddress = baseAddress;
			}
		}

		private Uri CreateUri(string uri)
		{
			if (string.IsNullOrEmpty(uri))
			{
				return null;
			}
			return new Uri(uri, UriKind.RelativeOrAbsolute);
		}

		public Task<HttpResponseMessage> GetJsonAsync(string requestUri, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = new CancellationToken())
		{
			return GetJsonAsync(CreateUri(requestUri), completionOption, cancellationToken);
		}

		public Task<HttpResponseMessage> GetJsonAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
		}

		public Task<HttpResponseMessage> GetXmlAsync(string requestUri, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = new CancellationToken())
		{
			return GetXmlAsync(CreateUri(requestUri), completionOption, cancellationToken);
		}

		public Task<HttpResponseMessage> GetXmlAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

			return SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
		}

		public Task<HttpResponseMessage> PostJsonAsync<T>(string requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			return PostJsonAsync(CreateUri(requestUri), value, cancellationToken);
		}

		public Task<HttpResponseMessage> PostJsonAsync<T>(Uri requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue) null);

			return base.SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri) {Content = content}, cancellationToken);
		}

		public Task<HttpResponseMessage> PostXmlAsync<T>(string requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			return PostXmlAsync(CreateUri(requestUri), value, cancellationToken);
		}

		public Task<HttpResponseMessage> PostXmlAsync<T>(Uri requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

			var content = new ObjectContent<T>(value, new XmlMediaTypeFormatter(), (MediaTypeHeaderValue)null);

			return base.SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content }, cancellationToken);
		}

		public Task<HttpResponseMessage> PutJsonAsync<T>(string requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			return PutJsonAsync(CreateUri(requestUri), value, cancellationToken);
		}

		public Task<HttpResponseMessage> PutJsonAsync<T>(Uri requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter(), (MediaTypeHeaderValue) null);

			return base.SendAsync(new HttpRequestMessage(HttpMethod.Put, requestUri) { Content = content }, cancellationToken);
		}

		public Task<HttpResponseMessage> PutXmlAsync<T>(string requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			return PutXmlAsync(CreateUri(requestUri), value, cancellationToken);
		}

		public Task<HttpResponseMessage> PutXmlAsync<T>(Uri requestUri, T value, CancellationToken cancellationToken = new CancellationToken())
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

			var content = new ObjectContent<T>(value, new XmlMediaTypeFormatter(), (MediaTypeHeaderValue)null);

			return base.SendAsync(new HttpRequestMessage(HttpMethod.Put, requestUri) { Content = content }, cancellationToken);
		}

		public Task<HttpResponseMessage> DeleteJsonAsync(string requestUri, CancellationToken cancellationToken = new CancellationToken())
		{
			return DeleteJsonAsync(CreateUri(requestUri), cancellationToken);
		}

		public Task<HttpResponseMessage> DeleteJsonAsync(Uri requestUri, CancellationToken cancellationToken = new CancellationToken())
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return base.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
		}

		public Task<HttpResponseMessage> DeleteXmlAsync(string requestUri, CancellationToken cancellationToken = new CancellationToken())
		{
			return DeleteXmlAsync(CreateUri(requestUri), cancellationToken);
		}

		public Task<HttpResponseMessage> DeleteXmlAsync(Uri requestUri, CancellationToken cancellationToken = new CancellationToken())
		{
			DefaultRequestHeaders.Accept.Clear();
			DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

			return base.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
		}
	}
}