/**
* @author kalstjd96@naver.com
* @brief
* @version 0.1
* @date 2025-03-22 01:06:25Z
*
* @copyright Copyright 2025 Kim MinSung, Co., LTD. All rights reserved.
*
*/
using UnityEngine;
using Utility;

namespace GoogleSDK.GoogleVoice.Internal
{
    public static class AudioConverter
    {
        public static AudioClip ToAudioClip(byte[] audioData)
        {
            // 기존 WavUtility.ToAudioClip 대체용 구현
            return WavUtility.ToAudioClip(audioData); 
        }

        public static byte[] ConvertClipTo16BitPCM(AudioClip clip)
        {
            float[] samples = new float[clip.samples];
            clip.GetData(samples, 0);

            byte[] byteArray = new byte[samples.Length * 2];
            int index = 0;
            foreach (var sample in samples)
            {
                short intSample = (short)(sample * 32767);
                byteArray[index++] = (byte)(intSample & 0xFF);
                byteArray[index++] = (byte)((intSample >> 8) & 0xFF);
            }
            return byteArray;
        }
    }

}
