using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> Changed;

    private float _timeToIncrease = 0.5f;
    private int _maxValue = int.MaxValue;
    private bool _isWorking = true;

    public int Increase { get; private set; } = 1;

    private IEnumerator Enumerator()
    {
        WaitForSeconds halfSecond = new WaitForSeconds(_timeToIncrease);

        for (int i = 0; i < _maxValue; i++)
        {
            Increase++;
            Changed?.Invoke(Increase);

            yield return halfSecond;
        }
    }

    public void StartWork()
    {
        if (_isWorking)
        {
            StartCoroutine(Enumerator());

            _isWorking = false;
        }
    }

    public void StopWork()
    {
        if (_isWorking == false)
        {
            StopAllCoroutines();

            _isWorking = true;
        }
    }
}
