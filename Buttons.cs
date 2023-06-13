using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void OnHeal()
    {
        SliderHpView.OnHealedPlayer(10);
    }

    public void OnGamage()
    {
        SliderHpView.OnDamagePlayer(10);
    }
}
