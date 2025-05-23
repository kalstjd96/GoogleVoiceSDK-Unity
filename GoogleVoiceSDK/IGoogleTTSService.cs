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
using UnityEngine;

namespace GoogleSDK.GoogleVoice
{
    public interface IGoogleTTSService
    {
        UniTask<AudioClip> SynthesizeSpeech(string text);
    }

}
