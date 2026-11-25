using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [Header("Player1 - Coin Balance")]

    [SerializeField] private int p1coinAmount = 0;
    [SerializeField] private int p1startingCoins = 7;
    [SerializeField] private TMPro.TMP_Text p1CoinCountTxt;



    [Header("Player2 - Coin Balance")]

    [SerializeField] private int p2coinAmount = 0;
    [SerializeField] private int p2startingCoins = 7;
    [SerializeField] private TMPro.TMP_Text p2CoinCountTxt;

    //text




    void Start()
    {
        p1coinAmount = p1startingCoins;
        p2coinAmount = p2startingCoins;

        UpdateCoinCount();
    }


    //ADD ==============================
    public void P1AddCoins(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        p1coinAmount += amount;

        Debug.Log($"Player1 earned {amount} of coins. Total: {p1coinAmount}");

        UpdateCoinCount();
    }

    public void P2AddCoins(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        p2coinAmount += amount;

        Debug.Log($"Player2 earned {amount} of coins. Total: {p2coinAmount}");

        UpdateCoinCount();
    }


    //SPEND ==============================
    public bool P1SpendCoins(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (p1coinAmount < amount)
        {
            return false;
        }

        p1coinAmount -= amount;

        Debug.Log($"Player1 spent {amount} of coins. Total: {p1coinAmount}");
        UpdateCoinCount();
        return true;
    }


    public void P2SpendCoins(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        if (p2coinAmount < amount)
        {
            return;
        }

        p2coinAmount -= amount;

        Debug.Log($"Player2 spent {amount} of coins. Total: {p2coinAmount}");
        UpdateCoinCount();
    }


    //turn coins into text

    public void UpdateCoinCount()
    {
        
        if (p1CoinCountTxt != null)
        {
            p1CoinCountTxt.text = "C: " + p1coinAmount;
        }

        if (p2CoinCountTxt != null)
        {
            p2CoinCountTxt.text = "C: " + p2coinAmount;
        }
    }



}//=========================================================================== End of bracket


