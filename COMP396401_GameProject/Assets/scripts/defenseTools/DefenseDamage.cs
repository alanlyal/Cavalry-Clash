using Core.FSM;

using UnityEngine;
public interface IDamageMethod
{
    public void DamageTick(InvadingPawnStateMachine Target);
    public void Init(int Damage, int RPM); //Init mean initialize 
}
public class DefenseDamage : MonoBehaviour, IDamageMethod
{
    private int Damage;
    private int RPM;
    private float delay;
    public void Init(int Damage, int RPM)
    {
        this.Damage = Damage;
        this.RPM = RPM;
        delay = 60 / RPM;
    }
    public void DamageTick(InvadingPawnStateMachine Target)
    {
        if (Target)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                return;
            }
            GameLoopManager.EnqueueDamageData(new EnemyDamageData(Target, Damage, Target.DamageResit));
            delay = 60 / RPM;
        }
    }
  
}
