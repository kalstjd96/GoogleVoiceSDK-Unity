# GoogleVoiceSDK for Unity

구글 STT/TTS 기능을 Unity에서 간편하게 사용할 수 있도록 만든 SDK입니다.

## ✅ 기능
- 마이크로 말한 내용을 실시간 음성 인식 (Google STT)
- 텍스트를 음성으로 변환하여 재생 (Google TTS)
- API Key 설정은 ScriptableObject로 단순화
- UniTask 기반 비동기 처리
- REST API 모듈화

## 🧩 구성
- GoogleVoiceSDK.dll
- GoogleVoiceConfig.cs (API Key 세팅용)
- GoogleVoiceExample.cs (예제)

## 📦 설치 방법
1. Unity 프로젝트에 `.unitypackage`를 Import 하세요
2. Newtonsoft Json 추가
3. UniTask 추가
4. `Resources` 폴더에 `GoogleVoiceConfig` 생성 후 API Key 입력
5. `IGoogleTTSService`, `IGoogleSTTService`를 통해 바로 사용 가능

## 🔗 필수 의존성

본 SDK는 [UniTask](https://github.com/Cysharp/UniTask)가 필요합니다.

### 설치 방법 (Package Manager)
Unity 메뉴 > Window > Package Manager > `+` 버튼 > "Add package from git URL"

## 📄 제3자 라이선스

### JSONObject (by Matt Schoen)
- License: [LGPL 2.1](http://www.opensource.org/licenses/lgpl-2.1.php)
- 포함 위치: `Dependencies/JSONObject`
- 목적: Google API 요청 시 JSON 구성 처리


## 🧪 사용 예시
```csharp
var tts = new GoogleTTSService(apiKey);
var audio = await tts.SynthesizeSpeech("안녕하세요");

