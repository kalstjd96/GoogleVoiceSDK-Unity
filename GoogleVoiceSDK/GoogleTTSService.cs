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
using GoogleSDK.GoogleVoice.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using Utility.RestApi;

namespace GoogleSDK.GoogleVoice
{
    public class GoogleTTSService : IGoogleTTSService
    {
        private readonly string apiKey;
        private readonly string apiUrl;

        public GoogleTTSService(string apiKey, string apiUrl)
        {
            this.apiKey = apiKey;
            this.apiUrl = apiUrl;
            RequestMicrophonePermission();
        }

        public void RequestMicrophonePermission()
        {
#if UNITY_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
#endif
        }

        public async UniTask<AudioClip> SynthesizeSpeech(string text)
        {
            var requestData = new JSONObject(new Dictionary<string, JSONObject>
        {
            { "input", new JSONObject(new Dictionary<string, string> { { "text", text } }) },
            { "voice", new JSONObject(new Dictionary<string, string> { { "languageCode", "ko-KR" }, { "ssmlGender", "NEUTRAL" } }) },
            { "audioConfig", new JSONObject(new Dictionary<string, string> { { "audioEncoding", "LINEAR16" } }) }
        });

            RestApiRequestOptions options = new RestApiRequestOptions(apiKey, Defines.RequestMethod.Post)
                .SetHeader(new() { ContentType = Defines.Header.ContentType.Application_Json })
                .SetBody(requestData);

            var client = new RestApiClient(options);
            var transfer = await client.RequestToApiServer(this.apiUrl);

            var response = JsonConvert.DeserializeObject<GoogleTTSResponse>(transfer.Body);
            if (response == null || string.IsNullOrEmpty(response.audioContent))
            {
                Debug.LogError("TTS   ȯ     :          ");
                return null;
            }

            try
            {
                byte[] audioData = Convert.FromBase64String(response.audioContent);
                return AudioConverter.ToAudioClip(audioData);
            }
            catch (Exception ex)
            {
                Debug.LogError("Base64    ڵ      : " + ex.Message);
                return null;
            }
        }

        [Serializable]
        public class GoogleTTSResponse
        {
            public string audioContent;
        }
    }

}
