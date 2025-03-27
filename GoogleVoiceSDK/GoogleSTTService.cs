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
using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.Android;
using Utility.RestApi;

namespace GoogleSDK.GoogleVoice
{
    public class GoogleSTTService : IGoogleSTTService
    {
        private readonly string apiKey;
        private readonly string apiUrl;
        private const int SampleRate = 16000;
        private const int RecordingTime = 10;
        public GoogleSTTService(string apiKey, string apiUrl)
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

        public async UniTask<string> RecognizeSpeech()
        {
            if (Microphone.IsRecording(null))
            {
                Debug.LogError("                    Դϴ !");
                return null;
            }

            if (Microphone.devices.Length == 0)
            {
                Debug.LogError("    ũ   ġ   ã           ϴ ");
                return null;
            }

            AudioClip recordedClip = Microphone.Start(null, false, RecordingTime, SampleRate);
            await UniTask.Delay(TimeSpan.FromSeconds(RecordingTime));
            Microphone.End(null);

            byte[] audioData = ConvertAudioClipToByteArray(recordedClip);
            if (audioData == null || audioData.Length == 0)
            {
                Debug.LogError("                  Ͱ       ֽ  ϴ ");
                return null;
            }

            return await SendAudioToRestAPI(audioData);
        }

        private async UniTask<string> SendAudioToRestAPI(byte[] audioData)
        {
            if (audioData == null || audioData.Length == 0)
            {
                Debug.LogError("                  Ͱ       ϴ ");
                return null;
            }

            string base64Audio = Convert.ToBase64String(audioData);

            var requestData = new
            {
                config = new
                {
                    encoding = "LINEAR16",
                    sampleRateHertz = SampleRate,
                    languageCode = "ko-KR"
                },
                audio = new
                {
                    content = base64Audio
                }
            };

            string jsonRequest = JsonConvert.SerializeObject(requestData);

            var options = new RestApiRequestOptions(this.apiKey, Defines.RequestMethod.Post)
                .SetHeader(new() { ContentType = Defines.Header.ContentType.Application_Json })
                .SetBody(jsonRequest);

            var client = new RestApiClient(options);
            var transfer = await client.RequestToApiServer(this.apiUrl);

            var response = JsonConvert.DeserializeObject<GoogleSTTResponse>(transfer.Body);
            if (response?.results == null || response.results.Length == 0)
            {
                Debug.LogError("STT             ϴ .");
                return null;
            }

            return response.results[0].alternatives[0].transcript;
        }


        private byte[] ConvertAudioClipToByteArray(AudioClip clip)
        {
            if (clip == null)
            {
                Debug.LogError("AudioClip is null Դϴ .");
                return null;
            }

            float[] samples = new float[clip.samples];
            clip.GetData(samples, 0);

            byte[] byteArray = new byte[samples.Length * 2];
            int index = 0;
            foreach (float sample in samples)
            {
                short convertedSample = (short)(sample * 32767);
                byteArray[index++] = (byte)(convertedSample & 0xff);
                byteArray[index++] = (byte)((convertedSample >> 8) & 0xff);
            }

            return byteArray;
        }

        [Serializable]
        public class GoogleSTTResponse
        {
            public Result[] results;
        }

        [Serializable]
        public class Result
        {
            public Alternative[] alternatives;
        }

        [Serializable]
        public class Alternative
        {
            public string transcript;
        }
    }
}
