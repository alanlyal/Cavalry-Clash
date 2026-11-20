using Unity.VisualScripting;
using UnityEngine;

public class PawnDamage : MonoBehaviour
{

    [Header("Pawn Damage")]
    [SerializeField] private int damage = 10;


    //DAMAGE ================================================================

    //Damage that pawn does =====================================
    public int GetDamage()
    {
        return damage;
    }



    //Pawn takes damage while in collision ================================
    private void OnTriggerStay(Collider other)
    {
        Health targetPawn = other.GetComponent<Health>();

       if(targetPawn != null){

            targetPawn.TakeDamage(damage);
            Debug.Log("Damage Taken:" + damage);
        }
    }

}
