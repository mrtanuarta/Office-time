using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public EventScriptable[] cards;
    public EventScriptable CurrCard;


    void start()
    {
        //make an algorithm to pick currcard based on the list of cards based on the weight
    }
    void update()
    {
        //if a card is swiped left or right pick a new card
    }
}
