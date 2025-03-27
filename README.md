# 🎙 Google Voice SDK for Unity

**Unity에서 Google Cloud의 STT(Speech-to-Text), TTS(Text-to-Speech) 기능을 간편하게 사용할 수 있도록 모듈화한 SDK입니다.
API Key만 등록하면 바로 음성 인식 및 음성 합성 기능을 구현할 수 있습니다.**

---

## 1. 설치 방법
1.  Releases 탭에서 .unitypackage 파일 다운로드
2. Unity에서 Assets > Import Package > Custom Package... 선택 후 가져오기
3. Resources/GoogleVoiceConfig.asset 생성하여 API Key 등록
4. Sample/GoogleVoiceSample 씬 실행(GoogleVoiceConfig.asset 변수에 등록) 또는 GoogleVoiceExample 사용

---

## 2. 사전 준비
1. Google Cloud Speech-to-Text, Text-to-Speech API 활성화
2. 발급한 API Key를 .asset 파일에 등록

---

## ✔ 3. 외부 의존 패키지 !! 
1. Newtonsoft.Json	: Unity 패키지 매니저 -> com.unity.nuget.newtonsoft-json 등록
2. UniTask	: .unitypackage 파일 직접 다운로드 후 가져오기 (https://github.com/Cysharp/UniTask)

---

## 4. 주요 기능

- Google Text-to-Speech (TTS)
- Google Speech-to-Text (STT)
- ScriptableObject 기반 API 키 관리
- UniTask 기반 비동기 처리
- REST API 요청 분리 (GoogleRequestHandler)
- 샘플 UI 포함

---

## 5. 패키지 구성

GoogleSDK/  <br>
├── Config/  <br>
│   └── GoogleVoiceConfig.asset    // API Key 입력  <br>
├── Dependencies/  <br>
│   ├── JSONObject/                // JSON 유틸  <br>
│   └── RestAPI/                   // API 통신 유틸  <br>
├── Plugins/  <br>
│   └── GoogleVoice/              // GoogleTTSService, GoogleSTTService  <br>
├── Sample/  <br>
│   └── GoogleVoiceExample.cs     // 테스트용 예제  <br>
└── Scene/  <br>
    └── GoogleVoiceSample.unity   // 샘플 씬  <br>


### 5-1 예제 적용 가이드
1. 빈 GameObject에 GoogleVoiceExample.cs 추가
2. GoogleVoiceConfig.asset을 인스펙터에 드래그하여 연결
3. TTS / STT 버튼을 UI 버튼에 할당
4. 빌드 or 플레이 → 음성 인식 / 음성 합성 동작 확인

### 5-2 API Key 설정
1. `Resources/` 폴더를 프로젝트 내에 생성합니다.
2. `GoogleVoiceConfig.asset` 파일을 생성합니다.  
   → 위치: `Assets/Resources/GoogleVoiceConfig.asset`

3. `GoogleVoiceConfig` 파일에 **Google Cloud API Key**를 입력합니다.

---

## 6. 라이선스 안내
JSONObject는 LGPL 2.1 기반입니다.

JSONObject class v.1.4.1 for use with Unity
Copyright Matt Schoen 2010 - 2013

본 패키지는 [Matt Schoen의 JSONObject (v1.4.1)](http://www.opensource.org/licenses/lgpl-2.1.php)를 기반으로 작성되었습니다.  
해당 소스는 LGPL 2.1에 따라 자유롭게 사용할 수 있습니다.  
라이센스 전문은 `Dependencies/JSONObject/LICENSE.txt` 참조 바랍니다.

---

💬 향후 계획
* WebGL 지원 확대
* 녹음 길이 조절
* 멀티 언어 설정 등 확장
  
Made with ☕ by [MinSung] | [kalstjd96@naver.com]
