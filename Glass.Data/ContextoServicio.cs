using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Data
{
    public class ContextoServicio
    {
        public String Url { get; }

        private RestClient Client { get; }

        public ContextoServicio(String url)
        {
            Url = url;
            Client = new RestClient(url);
        }

		public T Data<T>(String uri,
			Method method = Method.GET,
			Object body = null) where T : new()
		{
			return Response<T>(uri, method, body).Data;
		}

		public IRestRequest Request(String uri,
            Method method = Method.GET,
            Object body = null)
        {
            var rq = new RestRequest(uri, method);
            if (body != null) { rq.AddJsonBody(body); }
            return rq;
        }

		public IRestResponse<T> Response<T>(String uri,
			Method method = Method.GET,
			Object body = null) where T : new()
		{
			return Response<T>(Request(uri, method, body));
		}

		public IRestResponse<T> Response<T>(IRestRequest rq) where T : new()
		{
			var r = Client.Execute<T>(rq);
			return r;
		}
	}
}
