using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _timeToIncrease = 0.5f;
    private int _maxValue = int.MaxValue;
    private bool _isWorking = true;
    private string _counter = nameof(IncreaseCounter);

    public event Action<int> Changed;

    public int NumberForIncrease { get; private set; } = 1;

    private IEnumerator IncreaseCounter()
    {
        while (NumberForIncrease < _maxValue)
        {
            NumberForIncrease++;
            Changed?.Invoke(NumberForIncrease);

            yield return new WaitForSeconds(_timeToIncrease);
        }
    }

    public void StartWork()
    {
        if (_isWorking)
        {
            StartCoroutine(_counter);

            _isWorking = false;
        }
    }

    public void StopWork()
    {
        if (_isWorking == false)
        {
            StopCoroutine(_counter);

            _isWorking = true;
        }
    }
}
