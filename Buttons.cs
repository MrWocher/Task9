using UnityEngine;

public class Buttons : MonoBehaviour
{
    private int _heal = 10;
    private int _damage = 10;

    public void OnHeal()
    {
        SliderHpView.OnHealedPlayer(_heal);
    }

    public void OnGamage()
    {
        SliderHpView.OnDamagePlayer(_damage);
    }
}

