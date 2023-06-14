using UnityEngine;

public class PlayerParams : MonoBehaviour
{
    private int _maxHp = 100;
    private int _currentHp = 100;

    public void Heal(int heal)
    {
        _currentHp += heal;
        if(_currentHp > _maxHp)
            _currentHp = _maxHp;
        SliderHpView.OnHpChanged(_currentHp, _maxHp);
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
        if(_currentHp < 0)
            _currentHp = 0;
        SliderHpView.OnHpChanged(_currentHp, _maxHp);
    }
}
