using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHpView : MonoBehaviour
{
    [SerializeField] private PlayerParams playerParams;

    private Slider _slider;
    [SerializeField] private Text _txt;

    private float _sliderChangeSpeed = .25f;

    private Coroutine _changeHpSlider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        playerParams.HpChanged += StartChangeHpCoroutine;
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
