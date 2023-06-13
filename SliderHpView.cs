using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHpView : MonoBehaviour
{
    private static event Action<int> OnHealed;
    private static event Action<int> OnDamaged;
    private static event Action OnStartedHpChangeCoroutine;
 
    private int _maxHp;
    private int _currentHp
    {
        get { return _playerParams.currentHp; }
        set { _playerParams.currentHp = value; }
    }

    private Slider _hpSlider;
    [SerializeField] private Text _hpTxt;

    private PlayerParams _playerParams;

    private Coroutine _changeHpSlider;

    private void OnEnable()
    {
        _hpSlider = GetComponent<Slider>();
        _playerParams = FindObjectOfType<PlayerParams>();

        _maxHp = _playerParams.maxHp;

        OnHealed += _playerParams.Heal;
        OnDamaged += _playerParams.GetDamage;
        OnStartedHpChangeCoroutine += StartChangeHpCoroutine;
    }

    public static void OnHealedPlayer(int heal)
    {
        OnHealed?.Invoke(heal);
        OnStartHpChangeCoroutine();
    }
    public static void OnDamagePlayer(int damage)
    {
        OnDamaged?.Invoke(damage);
        OnStartHpChangeCoroutine();
    }
    public static void OnStartHpChangeCoroutine()
    {
        OnStartedHpChangeCoroutine?.Invoke();
    }

    private void StartChangeHpCoroutine()
    {
        if(_changeHpSlider != null)
            StopCoroutine( _changeHpSlider);
        _changeHpSlider = StartCoroutine(ChangeHpSlider());
    }

    private IEnumerator ChangeHpSlider()
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();

        _hpTxt.text = _currentHp.ToString();

        float _currentHpToFloat = _currentHp;
        float _maxHpToFloat = _maxHp;
        float targetValue = _currentHpToFloat / _maxHpToFloat;

        while (_hpSlider.value != targetValue)
        {
            _hpSlider.value = Mathf.MoveTowards(_hpSlider.value, targetValue, Time.fixedDeltaTime * 0.25f);
            yield return waitForEndOfFrame;
        }

    }
}
