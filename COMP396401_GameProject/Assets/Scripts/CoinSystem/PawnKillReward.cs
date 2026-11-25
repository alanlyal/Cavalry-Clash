using UnityEngine;
using UnityEngine.AI;

public class PawnKillReward : MonoBehaviour
{
    [SerializeField] private CoinSystem coinManager;
    [SerializeField] private int coinReward;

    public void Awake()
    {
        if (coinManager == null)
        {
            coinManager = FindAnyObjectByType<CoinSystem>();
        }
    }
    public void GiveReward()
    {
        if(coinManager == null) { return; }

        coinManager.P1AddCoins(coinReward);
        Debug.Log("Pawn Killed, Reward added: " + coinReward);
    }

}


