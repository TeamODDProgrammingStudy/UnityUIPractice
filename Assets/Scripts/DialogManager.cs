using System;
using System.Collections;
using System.Collections.Generic;
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
    }

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
