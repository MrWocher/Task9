using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHpView : MonoBehaviour
{
    public static event Action<float, float> HpChanged;

    private Slider _slider;
    [SerializeField] private Text _txt;

    private Coroutine _changeHpSlider;

    private float _sliderChangeSpeed = .25f;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        HpChanged += StartChangeHpCoroutine;
    }

    public static void OnHpChanged(float _currentHp, float _maxHp)
    {
        HpChanged?.Invoke(_currentHp, _maxHp);
    }

    private void StartChangeHpCoroutine(float _currentHp, float _maxHp)
    {
        if(_changeHpSlider != null)
            StopCoroutine( _changeHpSlider);
        _changeHpSlider = StartCoroutine(ChangeHpSlider(_currentHp, _maxHp));
    }

    private IEnumerator ChangeHpSlider(float _currentHp, float _maxHp)
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        _txt.text = _currentHp.ToString();

        float targetValue = _currentHp / _maxHp;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, Time.fixedDeltaTime * _sliderChangeSpeed);
            yield return waitForEndOfFrame;
        }

    }
}
