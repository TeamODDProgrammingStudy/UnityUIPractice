using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private Text _dialog;
    [SerializeField] private string[] _paragraph;
    [SerializeField] private bool _isPaused = false;
    private int _counter = 0;
    private void Start()
    {
        LoadParagraph();
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
    /*//스킵모드 코드
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
    public void LoadParagraph()
    {
        _dialog.text = _paragraph[_counter];
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
}
