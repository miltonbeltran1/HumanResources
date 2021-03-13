using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility.Helpers
{
    public interface IConsumeExternalService
    {
        public Task<T> RestAsync<T>(string url, HttpMethod method, object content = null,List<KeyValuePair<string, string>> headers = null);
    }
}
