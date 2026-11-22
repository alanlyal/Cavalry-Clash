using UnityEngine;
using System.Collections.Generic;
using Core.FSM;
public class GameLoopManager : MonoBehaviour
{
    public static readonly List<InvadingPawnStateMachine> CurrentEnemies = new List<InvadingPawnStateMachine>();
    public static readonly List<DefenseBehavoir> defensesInGame = new List<DefenseBehavoir>();
    public static Vector3[] NodePosition = new Vector3[1];
    public static float[] NodeDistances = new float[1];
    private DefenseBehavoir[] defenses;
    private void Start()
    {
        defenses = FindObjectsByType<DefenseBehavoir>(FindObjectsSortMode.None);
   }
    private void Update()
    {
        foreach (DefenseBehavoir defense in defensesInGame)
        {
            defense.target = DefenseTargeting.GetTarget(defense, DefenseTargeting.TargetType.Close);
            defense.Tick();
        }
    }
}
