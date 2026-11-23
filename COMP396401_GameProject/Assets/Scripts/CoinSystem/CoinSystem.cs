using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [Header("Coins")]
    private int coin = 1;
    [SerializeField] private int coinAmount = 1;
    [SerializeField] private int startingCoins = 7;

    //text
    [SerializeField] private TMPro.TMP_Text p1CoinCountTxt;
    [SerializeField] private TMPro.TMP_Text p2CoinCountTxt;

    //coin generation timer
    [Header("P2 Coin Generation")]
    [SerializeField] public float generationTimer = 5f;
    [SerializeField] private float generationTimerRemaining = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //coin generation
    public void coinGeneration(int amount)
    {
        coinAmount += amount;

        //add timer

        //text update
        P2CoinCount();
    }

    //coin take out value
    //coin gain more coins


    //turn coins into text

    public void P1CoinCount()
    {
        p1CoinCountTxt.text = "C: " + coinAmount;
    }


    public void P2CoinCount()
    {
        p2CoinCountTxt.text = "C: " + coinAmount;
    }
}


