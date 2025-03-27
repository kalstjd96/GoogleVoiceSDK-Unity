/**
* @author kalstjd96@naver.com
* @brief
* @version 0.1
* @date 2025-03-22 01:06:25Z
*
* @copyright Copyright 2025 Kim MinSung, Co., LTD. All rights reserved.
*
*/
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Utility.RestApi;
namespace GoogleSDK.GoogleVoice.Internal
{
    internal class GoogleRequestHandler
    {
        private static GoogleRequestHandler _instance;
        public static GoogleRequestHandler Instance => _instance ??= new GoogleRequestHandler();

        private readonly Dictionary<ApiType, string> _apiUrls = new()
        {
            { ApiType.GoogleTTS, "https://texttospeech.googleapis.com/v1/text:synthesize?key=" },
            { ApiType.GoogleSTT, "https://speech.googleapis.com/v1/speech:recognize?key=" },
        };

        public static async UniTask<IResponseTransfer> SendRequest(string apiKey, string _apiUrls, string jsonBody)
        {
            var options = new RestApiRequestOptions(apiKey, Defines.RequestMethod.Post)
                .SetHeader(new() { ContentType = Defines.Header.ContentType.Application_Json })
                .SetBody(jsonBody);


            var client = new RestApiClient(options);
            return await client.RequestToApiServer(_apiUrls);
        }
        public enum ApiType
        {
            GoogleTTS,
            GoogleSTT,
        }
    }
}
