using UnityEngine;

public class PlayerParams : MonoBehaviour
{
    private int _maxHp = 100;
    private int _currentHp = 100;
    public int maxHp
    {
        get { return _maxHp; }
    }
    public int currentHp { 
        get { return _currentHp; }
        set { _currentHp = value; } 
    }

    public void Heal(int heal)
    {
        _currentHp += heal;
        if(_currentHp > _maxHp)
            _currentHp = _maxHp;
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
        if(_currentHp < 0)
            _currentHp = 0;
    }
}
