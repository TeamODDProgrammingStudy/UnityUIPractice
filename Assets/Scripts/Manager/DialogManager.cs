using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Manager
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private Text _dialog;
        [SerializeField] private string[] _paragraph;
        [SerializeField] private TextAsset _textAssetJson;
        [SerializeField] private TextAsset _textAssetXML;
        [SerializeField] private bool _isPaused = false;
        [SerializeField] private float _dialogTypeRatio = 0.1f;
        [SerializeField] private UnityEvent _onDialogTypeEvent;
        private int _counter = 0;
        private bool _isDialogAnimationStart = false;
        private void Start()
        {
            //LoadJsonData();
            LoadXMLData();
            LoadParagraph();
        }

        private void LoadJsonData()
        {
            var data = JsonConvert.DeserializeObject<DialogScripts>(_textAssetJson.text);
            if (data != null) _paragraph = data.Scripts;
        }
        private void LoadXMLData()
        {
            StringReader reader = new StringReader(_textAssetXML.text);
            XmlSerializer serializer = new XmlSerializer(typeof(DialogScripts));
            var data = serializer.Deserialize(reader) as DialogScripts;
            if (data != null) _paragraph = data.Scripts;
        }
        private void Update()
        {
            if (_isPaused) {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadParagraph();
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.currentSelectedGameObject) {
                    LoadParagraph();
                }
            }
            //SkipMode();//스킵 모드 함수
        }
        public void LoadParagraph()
        {
            if (!_isDialogAnimationStart) {
                StartCoroutine(DialogTypingAnimation(_counter));
            }
            else
            {
                _dialog.text = _paragraph[_counter];
            }
        }

        private IEnumerator DialogTypingAnimation(int paragraphNumber)
        {
            _isDialogAnimationStart = true;
            int length = 1;
            while (!_dialog.text.Equals(_paragraph[paragraphNumber]))
            {
                if (!_isPaused)
                {
                    _dialog.text = _paragraph[paragraphNumber].Substring(0, length);
                    length++;
                    _onDialogTypeEvent.Invoke();//이벤트 실행을 통해 사운드 출력
                }
                yield return new WaitForSecondsRealtime(_dialogTypeRatio);
            }
            _isDialogAnimationStart = false;
            _counter++;
            _counter %= _paragraph.Length;
        }
        public void DialogPause()
        {
            _isPaused = true;
        }
        public void DialogStart()
        {
            _isPaused = false;
        }
        /*//스킵모드 함수
    private float _startTime = 0; // 스킵 입력 시작 변수
    private bool _startSkipTimer = false; // 스킵 타이머 시작 여부를 저장하는 변수
    private float _pastSkipTime = 0f; // 이전 출력 시기를 저장하는 변수
    private float _skipRatio = 0.5f; // 스킵 주기 변수
    private void SkipMode()
    {
        //마우스를 꾹 누르고 있는 입력을 받음
        if (Input.GetMouseButton(0)) {
            //입력시 스킵 타이머가 동작하지 않았을 경우 현재 시간을 변수에 저장하고 타이머 실행 여부를 True로 바꿈
            if (!_startSkipTimer) {
                _startTime = Time.time;
                _startSkipTimer = true;
            }
        }
        else {
            //입력이 없으면 타이머 초기화
            _startTime = 0;
            _startSkipTimer = false;
        }
        //스킵 타이머가 작동하고 있었고 그 주기가 1.5초를 초과하면 스킵 실행
        if (_startSkipTimer &&Time.time - _startTime > 1.5f) {
            //현재 시간에 이전 스킵 시간을 뺀 값이 주기 값보다 크면 문장 출력 및 이전 스킵 시간 저장
            if (Time.time - _pastSkipTime > _skipRatio) {
                LoadParagraph();
                _pastSkipTime = Time.time;
            }
            
        }
    }
    */
    }
}
