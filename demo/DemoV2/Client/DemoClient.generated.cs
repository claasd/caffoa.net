using Caffoa;
using Caffoa.Defaults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using DemoV2.Model.Base;
using DemoV2.Model;


namespace DemoV2.Client
{
    /// AUTO GENERATED CLASS
    public partial class DemoClient
    {
        private string _baseUri;
        internal string BaseUri {
            get => _baseUri;
            set => _baseUri = value.EndsWith("/") ? value : $"{value}/";
        }
        internal HttpClient Client { get; }
        internal ILogger Logger { get; }
        internal ICaffoaParseErrorHandler ErrorHandler  { get; }
        internal ICaffoaJsonParser JsonParser { get; }
        internal ICaffoaJsonSerializer JsonSerializer { get; }
        private DemoClient(string baseUri, HttpClient client = null, ILogger logger = null, ICaffoaParseErrorHandler errorHandler = null, ICaffoaJsonParser jsonParser = null, ICaffoaJsonSerializer jsonSerializer = null) {
            BaseUri = baseUri;
            Client = client ?? new HttpClient();
            Logger = logger ?? NullLogger.Instance;
            JsonSerializer = jsonSerializer ?? new DefaultCaffoaResultHandler();
            ErrorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(Logger, JsonSerializer);
            JsonParser = jsonParser ?? new DefaultCaffoaJsonParser(ErrorHandler);
        }
        partial void PrepareRequest(HttpRequestMessage msg);
        partial void ProcessResponse(HttpResponseMessage msg);

        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        public async Task<IReadOnlyList<AnyCompleteUser>> UsersGetAsync(int? offset = 0, int? limit = 1000, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users");
            var queryBuilder = new QueryBuilder();
            if(offset != null)
                queryBuilder.Add("offset", $"{offset}");
            if(limit != null)
                queryBuilder.Add("limit", $"{limit}");
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                try
                {
                    if((int)httpResult.StatusCode == 400)
                        throw new CaffoaWebClientException<Error>(400, JsonParser.Parse<Error>(errorData), errorData);
                }
                catch (Exception e) when(e is not CaffoaWebClientException)
                {
                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
                }

                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<AnyCompleteUser>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        public async Task<IReadOnlyList<AnyCompleteUser>> UserPostAsync(User payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, MediaTypeNames.Application.Json);
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<AnyCompleteUser>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// create or update a user without return test
        /// 201 -> User was created
        /// </summary>
        public async Task<IReadOnlyList<AnyCompleteUser>> UserPostAsync(GuestUser payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, MediaTypeNames.Application.Json);
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<AnyCompleteUser>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, User payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/{userId}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, MediaTypeNames.Application.Json);
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<AnyCompleteUser>(resultStream);
            return (resultObject, (int)httpResult.StatusCode);
        }

        /// <summary>
        /// create or update a user
        /// 200 -> User was updated
        /// 201 -> User was created
        /// </summary>
        public async Task<(AnyCompleteUser, int)> UserPutAsync(string userId, GuestUser payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/{userId}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, MediaTypeNames.Application.Json);
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<AnyCompleteUser>(resultStream);
            return (resultObject, (int)httpResult.StatusCode);
        }

        /// <summary>
        /// update a user
        /// 200 -> User was updated
        /// </summary>
        public async Task<UserWithId> UserPatchAsync(string userId, JObject payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/{userId}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Patch, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, MediaTypeNames.Application.Json);
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<UserWithId>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// get information about the users
        /// 200 -> return user object
        /// </summary>
        public async Task<UserWithId> UserGetAsync(string userId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/{userId}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<UserWithId>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 201 -> Image was created
        /// </summary>
        public async Task UploadImageAsync(string userId, Stream stream, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/{userId}/uploadImage");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            httpRequest.Content = new StreamContent(stream);
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
        }

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        public async Task<IReadOnlyList<User>> UsersGetByBirthdateAsync(DateOnly date, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/born-before/{date:yyyy-MM-dd}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                try
                {
                    if((int)httpResult.StatusCode == 400)
                        throw new CaffoaWebClientException<Error>(400, JsonParser.Parse<Error>(errorData), errorData);
                }
                catch (Exception e) when(e is not CaffoaWebClientException)
                {
                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
                }

                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<User>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// get
        /// 200 -> return user object
        /// 400 -> Error
        /// </summary>
        public async Task<IReadOnlyList<User>> UsersSearchByDateAsync(DateOnly before, DateOnly after, int? maxResults = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}users/filter/byAge");
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("before", before.ToString("yyyy-MM-dd"));
            queryBuilder.Add("after", after.ToString("yyyy-MM-dd"));
            if(maxResults != null)
                queryBuilder.Add("maxResults", $"{maxResults}");
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                try
                {
                    if((int)httpResult.StatusCode == 400)
                        throw new CaffoaWebClientException<Error>(400, JsonParser.Parse<Error>(errorData), errorData);
                }
                catch (Exception e) when(e is not CaffoaWebClientException)
                {
                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
                }

                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<User>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// start a long running function via durable functions
        /// 202 -> started long running function
        /// </summary>
        public async Task<LongRunningfunctionStatus> LongRunningFunctionAsync(Guid id, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}startLongRunningFunction/{id}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<LongRunningfunctionStatus>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> list of elements that have the requested tag
        /// </summary>
        public async Task<TagInfos> GetTagsAsync(CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}tags");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<TagInfos>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> tags for the user
        /// </summary>
        public async Task<IReadOnlyDictionary<string, Guid>> GetUserTagsAsync(CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}tags/users");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<Dictionary<string, Guid>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        public async Task<IReadOnlyList<MyEnumType>> ListEnumsAsync(MyEnumType? filter = null, ICollection<MyEnumType>? include = null, ICollection<string>? flags = null, ICollection<MyEnumType>? exclude = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}enums/list");
            var queryBuilder = new QueryBuilder();
            if(filter != null)
                queryBuilder.Add("filter", filter.Value());
            if(include != null)
                queryBuilder.Add("include", include.AsStringList());
            if(flags != null)
                queryBuilder.Add("flags", $"{flags}");
            if(exclude != null)
                queryBuilder.Add("exclude", exclude.AsStringList());
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<MyEnumType>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> a list of neum
        /// </summary>
        public async Task<IReadOnlyList<MyEnumType>> ListEnums2Async(MyEnumType filter, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder($"{BaseUri}enums/list/filter/{filter.Value()}");
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<MyEnumType>>(resultStream);
            return resultObject;
        }
    }
}