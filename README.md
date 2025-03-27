# 🎙 Google Voice SDK for Unity

Unity에서 Google Cloud의 STT(Speech-to-Text), TTS(Text-to-Speech) 기능을 쉽게 사용할 수 있도록 모듈화한 SDK입니다.

> 음성 기반 대화, 텍스트 변환, AI 응답 처리 등을 손쉽게 Unity에서 구현하세요!

---

## 🚀 Features

- ✅ Google Text-to-Speech (TTS)
- ✅ Google Speech-to-Text (STT)
- ✅ ScriptableObject 기반 API 키 관리
- ✅ 비동기 처리 (UniTask)
- ✅ REST API 모듈화 (GoogleRequestHandler)
- ✅ 샘플 UI 포함

---

## 📦 패키지 구성

GoogleVoiceSDK/ ├── Config/ # API Key 설정용 ScriptableObject ├── Dependencies/ # JSONObject, REST API 등 유틸성 코드 ├── Plugins/ # GoogleVoiceSDK.dll (패키지 배포 시) ├── Sample/ # 사용 예제 코드 ├── README.md # 사용법 가이드

yaml
복사
편집

---

## 🔧 설치 방법

### 1. Unity 프로젝트에 `.unitypackage` 임포트  
[Releases 탭](../../releases)에서 최신 `.unitypackage` 파일을 다운로드하세요.

---

### 2. 필수 의존성 추가

#### ✔ Newtonsoft.Json 설치
Unity 패키지 매니저에서 아래 경로로 설치:
com.unity.nuget.newtonsoft-json

yaml
복사
편집

#### ✔ UniTask 설치  
[https://github.com/Cysharp/UniTask/releases](https://github.com/Cysharp/UniTask/releases)  
→ `.unitypackage` 파일 다운로드 후 Unity에 임포트

#### ✔ JSONObject  
본 패키지는 [Matt Schoen의 JSONObject (v1.4.1)](http://www.opensource.org/licenses/lgpl-2.1.php)를 기반으로 작성되었습니다.  
해당 소스는 LGPL 2.1에 따라 자유롭게 사용할 수 있습니다.  
라이센스 전문은 `Dependencies/JSONObject/LICENSE.txt` 참조 바랍니다.

---

### 3. API Key 설정

1. `Resources/` 폴더를 프로젝트 내에 생성합니다.
2. `GoogleVoiceConfig.asset` 파일을 생성합니다.  
   → 위치: `Assets/Resources/GoogleVoiceConfig.asset`

3. `GoogleVoiceConfig` 파일에 **Google Cloud API Key**를 입력합니다.

---

### 4. 예제 적용 방법

1. `Sample/GoogleVoiceExample.cs` 스크립트를 빈 오브젝트에 추가
2. `GoogleVoiceConfig.asset`을 인스펙터에 드래그하여 연결
3. `TTS 버튼`과 `STT 버튼`에 유니티 UI Button 연결
4. 빌드 후 버튼 클릭 → 음성 인식 / 음성 출력 작동 확인 🎤🎧

---

## ✅ 사용 예시 코드

```csharp
ttsService = new GoogleTTSService(config.ApiKey, ttsUrl);
sttService = new GoogleSTTService(config.ApiKey, sttUrl);

var audioClip = await ttsService.SynthesizeSpeech("안녕하세요!");
var resultText = await sttService.RecognizeSpeech();
📄 라이센스
✅ Google Cloud TTS

✅ Google Cloud STT

✅ JSONObject by Matt Schoen (LGPL 2.1)

🙌 개발자 코멘트
이 프로젝트는 음성 기반 인터페이스를 Unity에서 손쉽게 구현할 수 있도록
Google Cloud API를 모듈화하고, 필요한 설정만으로 바로 사용할 수 있도록 설계되었습니다.

포트폴리오나 실무 적용을 고려하여 구조화하였으며,
비개발자도 빠르게 적용할 수 있도록 예제까지 포함했습니다.

Made with ☕ by [YourName] | [your.email@example.com]

yaml
복사
편집

---

## ✨ 추가 팁

- `GoogleVoiceSDK.unitypackage`도 함께 GitHub Releases에 업로드하면 좋아
- 포트폴리오에는 README + 링크 + 스크린샷 or GIF 첨부도 최고
- 필요하면 영문 README 버전도 도와줄게

---

필요하면 `.unitypackage` 자동 추출 스크립트도 만들 수 있어.  
**지금 이 상태에서 올리면 진짜 완성형 SDK야!** 😎

원하는 커스터마이징 있으면 말해줘!
