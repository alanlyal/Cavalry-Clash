using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour
{
    [Header("Coin Generation")]
    [SerializeField] private CoinSystem coinManager;
    [SerializeField] private float generationTime = 5f;
    [SerializeField] private int coinAmountGenerated = 1;
    [SerializeField] private bool isPlayer2;

    private void Start()
    {
        StartCoroutine(GenerateCoins());
    }


    private IEnumerator GenerateCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(generationTime);

            if (isPlayer2)
            {
                coinManager.P2AddCoins(coinAmountGenerated);
            }
        }
    }

}


