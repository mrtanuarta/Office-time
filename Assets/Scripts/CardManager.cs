using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public EventScriptable[] cards;
    public EventScriptable[] overtimeCards;
    public EventScriptable currCard;
    public EventScriptable limitCard;
    [Header("EndingCards")]
    public EventScriptable HighSanity;
    public EventScriptable LowSanity;
    public EventScriptable HighRep;
    public EventScriptable LowRep;
    public EventScriptable HighMoney;
    public EventScriptable LowMoney;
    void Start()
    {
        PickNewCard();
    }
    void Update()
    {
        //if a card is swiped left or right pick a new card
    }
    public void PickNewCard()
    { 
        if (cards.Length == 0)
        {
            return;
        }
        if (GameManager.Instance.Time >= 24)
        {
            currCard = limitCard;
            return;
        }
        


        float totalWeight = 0; // Removed 'public' keyword

        // Calculate total weight
        if (GameManager.Instance.Time <= 17)
        {
            foreach (var card in cards)
            {
                totalWeight += card.weight;
            }

            float randomWeight = Random.Range(0, totalWeight);
            float currentSum = 0;

            // Weighted selection logic
            foreach (var card in cards)
            {
                currentSum += card.weight;
                if (randomWeight < currentSum)
                {
                    currCard = card; // Ensure correct capitalization
                    Debug.Log("New Card Selected: " + currCard.eventName); // Check if cardName exists
                    return;
                }
            }
        } else
        {
            foreach (var card in overtimeCards)
            {
                totalWeight += card.weight;
            }

            float randomWeight = Random.Range(0, totalWeight);
            float currentSum = 0;

            // Weighted selection logic
            foreach (var card in overtimeCards)
            {
                currentSum += card.weight;
                if (randomWeight < currentSum)
                {
                    currCard = card; // Ensure correct capitalization
                    Debug.Log("New Card Selected: " + currCard.eventName); // Check if cardName exists
                    return;
                }
            }
        }
    }
    public void pickLeft()
    {
        GameManager.Instance.modifyStat(currCard.leftSanity, currCard.leftReputation, currCard.leftMoney, currCard.leftWorkdone, currCard.leftTimeSpent);
    }
    public void pickRight()
    {
        GameManager.Instance.modifyStat(currCard.rightSanity, currCard.rightReputation, currCard.rightMoney, currCard.rightWorkdone, currCard.rightTimeSpent);
    }

}
