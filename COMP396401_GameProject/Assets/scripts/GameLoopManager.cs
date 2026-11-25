using UnityEngine;
using System.Collections.Generic;
using Core.FSM;
public class GameLoopManager : MonoBehaviour
{
    public static readonly List<InvadingPawnStateMachine> CurrentEnemies = new List<InvadingPawnStateMachine>();
    public static readonly List<DefenseBehavoir> defensesInGame = new List<DefenseBehavoir>();
    public static Vector3[] NodePosition = new Vector3[1];
    public static float[] NodeDistances = new float[1];
    public static Queue<EnemyDamageData> damageData;
    private DefenseBehavoir[] defenses;
    private void Start()
    {
        damageData = new Queue<EnemyDamageData>();
        defenses = FindObjectsByType<DefenseBehavoir>(FindObjectsInactive.Exclude);
   }
    private void Update()
    {
        foreach (DefenseBehavoir defense in defensesInGame)
        {
            defense.target = DefenseTargeting.GetTarget(defense, DefenseTargeting.TargetType.Close);
            defense.Tick();
        }
        while (damageData.Count > 0)
        {
            for (int i = 0; i < damageData.Count; i++)
            {
                EnemyDamageData CurrentDamageData = damageData.Dequeue();
                if (CurrentDamageData.TargetedEnemy == null)
                {
                    continue;
                }
                Health health = CurrentDamageData.TargetedEnemy.GetComponent<Health>();
                health.TakeDamage(CurrentDamageData.TotalDamage / CurrentDamageData.Resistance);
                if (health.health <= 0)
                {
                    EnqueueEnemyToRemove(CurrentDamageData.TargetedEnemy);
                }
            }
        }
    }
    public static Queue<InvadingPawnStateMachine> EnemiesToRemove = new Queue<InvadingPawnStateMachine>();
    public static void EnqueueEnemyToRemove(InvadingPawnStateMachine enemy)
    {
        EnemiesToRemove.Enqueue(enemy);
    }
    public static void EnqueueDamageData(EnemyDamageData newdamageData)
    {
        damageData.Enqueue(newdamageData);
    }
}
public struct EnemyDamageData
{

    public EnemyDamageData(InvadingPawnStateMachine target, int damage, int resistance)
    {
        TargetedEnemy = target;
        TotalDamage = damage;
        Resistance = resistance;
    }
    public InvadingPawnStateMachine TargetedEnemy;
    public int TotalDamage;
    public int Resistance;

}
