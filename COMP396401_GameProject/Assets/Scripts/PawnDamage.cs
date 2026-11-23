using UnityEngine;

public class PawnDamage : MonoBehaviour
{

    [Header("Pawn Damage")]
    [SerializeField] private int damage = 10;

    private LevelManager levelManager;

    public void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }


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
            return;
        }

        //Check if hitting castle
        if (levelManager != null && levelManager.IsCastle(other))
        {
            levelManager.DamageCastle(damage);
            Debug.Log ("Castle Damage Taken: " + damage);
            Destroy(gameObject);
        }
    }

}
