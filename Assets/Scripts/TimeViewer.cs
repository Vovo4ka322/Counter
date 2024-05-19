using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMash;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnChanged;
    }

    private void OnChanged(int value)
    {
        _textMash.text = _counter.Increase.ToString();
    }
}
