using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _timeToIncrease = 0.5f;
    private int _maxValue = int.MaxValue;
    private bool _isWorking = true;
    private IEnumerator _coroutine;

    public event Action<int> Changed;

    public int NumberForIncrease { get; private set; } = 1;

    private void Start()
    {
        _coroutine = IncreaseCounter();
    }

    public void StartWork()
    {
        if (_isWorking)
        {
            StartCoroutine(_coroutine);

            _isWorking = false;
        }
    }

    public void StopWork()
    {
        if (_isWorking == false && _coroutine != null)
        {
            StopCoroutine(_coroutine);

            _isWorking = true;
        }
    }

    private IEnumerator IncreaseCounter()
    {
        WaitForSeconds halfSecond = new(_timeToIncrease);

        while (NumberForIncrease < _maxValue)
        {
            NumberForIncrease++;
            Changed?.Invoke(NumberForIncrease);

            yield return halfSecond;
        }
    }
}
