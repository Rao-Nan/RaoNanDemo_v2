using demo.Facebook.ApiResponse;
using demo.HttpClient.Attributes;
using demo.HttpClient.Attributes.Parameter;
using demo.HttpClient.Attributes.Route;
using RestSharp;

namespace demo.Facebook
{
    [BaseUrl("https://graph.facebook.com")]
    public interface IFacebookGraphApiClient
    {


        /// <summary>
        /// 短期令牌
        /// </summary>
        /// <param name="redirect_uri"></param>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [Route("v11.0/oauth/access_token")]
        [HttpGet]
        IRestResponse<AccountTokenResponse> GetUserToken([QueryString] string redirect_uri, [QueryString] string client_id, [QueryString] string client_secret, [QueryString] string code);

        /// <summary>
        /// 长期令牌
        /// </summary>
        /// <param name="fb_exchange_token"></param>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        /// <param name="grant_type"></param>
        /// <returns></returns>
        [Route("v11.0/oauth/access_token")]
        [HttpGet]
        IRestResponse<AccountTokenResponse> GetUserLongToken([QueryString] string fb_exchange_token, [QueryString] string client_id, [QueryString] string client_secret, [QueryString] string grant_type = "fb_exchange_token");

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="fb_exchange_token"></param>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        /// <param name="grant_type"></param>
        /// <returns></returns>
        [Route("v11.0/me/adaccounts")]
        [HttpGet]
        IRestResponse<FacebookListResult<AdAccountsResponse>> GetAdAccounts([QueryString] string fields, [HeaderParam("authorization")] string token);

        [Route("v11.0/me/adaccounts")]
        [HttpGet]
        IRestResponse<FacebookListResult<AdAccountsResponse>> GetAdAccounts([QueryString] string fields, [QueryString] int limit, [HeaderParam("authorization")] string token);



        [Route("v11.0/{adAccountId}")]
        [HttpGet]
        IRestResponse<AdAccountsResponse> GetAdAccount([PathParam] string adAccountId, [QueryString] string fields, [HeaderParam("authorization")] string token);

        [Route("v9.0/{Id}/insights")]
        [HttpGet]
        IRestResponse<FacebookListResult<AdAccountInsightResponse>> GetAdAccountInsightById([PathParam] string Id, [HeaderParam("authorization")] string token,[QueryString] string time_range = null);

        [Route("v11.0/{Id}/insights")]
        [HttpGet]
        IRestResponse<FacebookListResult<AdAccountInsightResponse>> GetAdAccountInsightById_V11([PathParam] string Id, [HeaderParam("authorization")] string token);



    }
}
