using Core.FSM;
using UnityEngine;

public class DefenseBehavoir : MonoBehaviour
{
    public float Damage;
    public float RPM; //Rounde per minute or jsut fire rate
    public float Range;
    public Transform DefRotation; // def is short for Defense
    public InvadingPawnStateMachine target;
    public LayerMask EnemiesLayer;
    private float Delay;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Delay = 1 / RPM; 
    }

    // Update is called once per frame
    public void Tick()
    {
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
