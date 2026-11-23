using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] private int maxHealth = 150;
    [SerializeField] public int health = 100;
    private bool dead = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Health should not be set to max health as maxhealth is the cap

    }

    // Update is called once per frame
    void Update()
    {
       


    }


    //Health & Damage =====================================
    //Checks if players dead, clamps health to the max health, applies damage to health
    public void TakeDamage(int damage)
    {
        if (dead)
        {
            return;
        }


        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        Debug.Log("Health:" +  health);

        if (health <= 0)
        {
            Dead();
        }

       
    }

    ///Dead =======================================

    private void Dead()
    {
        dead = true;

        if (CompareTag("Enemy"))
        {
            PawnKillReward reward = GetComponent<PawnKillReward>();

            if (reward != null)
            {
                reward.GiveReward();
            }

        }

        Destroy(gameObject);
    }


    //Health Upgrade / Heal =====================================
    //Pawn can either be healed to full health or upgraded to full health
    public void Heal(int amount)
    {
        if (dead)
        {
            return;
        }

        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);

    }

}

