using Core.FSM;
using UnityEngine;

public class DefenseBehavoir : MonoBehaviour
{
    public int Damage;
    public int RPM; //Rounde per minute or jsut fire rate
    public float Range;
    public Transform DefRotation; // def is short for Defense
    public InvadingPawnStateMachine target;
    public LayerMask EnemiesLayer;
    private IDamageMethod CurrentDamageMethod;
    private float Delay;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        CurrentDamageMethod = GetComponent<IDamageMethod>();
        if (CurrentDamageMethod == null)
        {
            Debug.LogError("Defense are missing damage class attached to the defense");
        }
        else
        {
            CurrentDamageMethod.Init(Damage, RPM);
        }
       
            Delay = 1 / RPM; 
    }

    // Update is called once per frame
    public void Tick()
    {
        CurrentDamageMethod.DamageTick(target);
        if (target != null)
        {
            DefRotation.transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        }
    }
 

    private void OnEnable()
    {
        GameLoopManager.defensesInGame.Add(this);
    }
    private void OnDisable()
    {
        GameLoopManager.defensesInGame.Remove(this);
    }
}
