using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float Sanity;
    [SerializeField] public float Reputation;
    [SerializeField] public float Money;
    [SerializeField] public float Workdone;
    [SerializeField] public int Time;
    [SerializeField] public int Day = 1;
    public bool GameOver;
    public static GameManager Instance { get; private set; }

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
    void Start()
    {
        Sanity = 50;
        Reputation = 50;
        Money = 50;
        Workdone = 0;
        Time = 9;
        GameOver = false;
    }

    // Update is called once per frame

    void printCurStat()
    {
        Debug.Log("Sanity = " + Sanity +
                "\nReputation = " + Reputation +
                "\nMoney = " + Money +
                "\nWorkdone = " + Workdone +
                "\nTime = " + Time
                );             
    }
    public void modifyStat(float sanityAmt, float reputationAmt, float moneyAmt, float workdoneAmt, int timeAmt)
    {
        Sanity += sanityAmt;
        Reputation += reputationAmt;
        Money += moneyAmt;
        Workdone += workdoneAmt;
        Time += timeAmt;
        printCurStat();
        checkGameStat();
    }
    public void checkGameStat()
    {
        if (Sanity >= 100)
        {
            Debug.Log("Game Over");
            GameOver = true;
            Sanity = 100;
        } 
        else if (Sanity <= 0)
        {
            Debug.Log("Game Over");
            GameOver = true;
            Sanity = 0;
        }
        if (Reputation >= 100)
        {
            Debug.Log("Game Over");
            GameOver = true;
            Reputation = 100;
        }
        else if (Reputation <= 0)
        {
            Debug.Log("Game Over");
            GameOver = true;
            Reputation = 0;
        }
        if (Money >= 100)
        {
            Debug.Log("Game Over");
            GameOver = true;
            Money = 100;
        }
        else if (Money <= 0)
        {
            Debug.Log("Game Over");
            GameOver = true;
            Money = 0;
        } 
        if (Time >= 24)
        {
            Day++;
            Time = 9;
        }
    }
}
