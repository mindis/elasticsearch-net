﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Elasticsearch.Net.Connection.HttpClient
{
	public class ElasticsearchHttpClient : IConnection
	{
		private IConnectionConfigurationValues _settings;

		public ElasticsearchHttpClient(IConnectionConfigurationValues settings)
		{
			_settings = settings;
		}

		public ElasticsearchResponse<Stream> DoSyncRequest<T>(string method, Uri uri, byte[] data = null)
		{
			var client = new System.Net.Http.HttpClient();
			HttpResponseMessage response = null;
			HttpContent content = null;
			if (data != null)
				content = new ByteArrayContent(data);
			switch (method.ToLower())
			{
				case "head":
					response = client.SendAsync(new HttpRequestMessage(HttpMethod.Head, uri)).Result;
					break;
				case "delete":
					response = client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, uri) { Content = content }).Result;
					break;
				case "put":
					response = client.PutAsync(uri, content).Result;
					break;
				case "post":
					response = client.PostAsync(uri, content).Result;
					break;
				case "get":
					response = client.GetAsync(uri).Result;
					break;
			}
			if (response == null)
				return ElasticsearchResponse<Stream>.CreateError(_settings, null, method, uri.ToString(), data);
			using (var result = response.Content.ReadAsStreamAsync().Result)
			{
				var cs = ElasticsearchResponse<Stream>.Create(this._settings, (int)response.StatusCode, method, uri.ToString(), data, result);
				return cs;
			}
		}



		public Task<ElasticsearchResponse<Stream>> Get(Uri uri, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public ElasticsearchResponse<Stream> GetSync(Uri uri, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public Task<ElasticsearchResponse<Stream>> Head(Uri uri, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public ElasticsearchResponse<Stream> HeadSync(Uri uri, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public Task<ElasticsearchResponse<Stream>> Post(Uri uri, byte[] data, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public ElasticsearchResponse<Stream> PostSync(Uri uri, byte[] data, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public Task<ElasticsearchResponse<Stream>> Put(Uri uri, byte[] data, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public ElasticsearchResponse<Stream> PutSync(Uri uri, byte[] data, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public Task<ElasticsearchResponse<Stream>> Delete(Uri uri, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public ElasticsearchResponse<Stream> DeleteSync(Uri uri, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public Task<ElasticsearchResponse<Stream>> Delete(Uri uri, byte[] data, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

		public ElasticsearchResponse<Stream> DeleteSync(Uri uri, byte[] data, IRequestConnectionConfiguration requestSpecificConfig = null)
		{
			throw new NotImplementedException();
		}

	}
}
