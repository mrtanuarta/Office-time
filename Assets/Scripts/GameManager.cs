using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Sanity;
    public float Reputation;
    public float Money;
    public float Workdone;
    public int Time;
    public int Day = 1;
    public bool GameOver;
    public string TimeStatus;
    public float maxWork;
    public float workDif;
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
        maxWork = 50;
        GameOver = false;
        TimeStatus = "Clock In";
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
        TimeStatusChange();
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
        
        if (Time > 100 || Workdone >= maxWork)
        {
            Day++;
            Time = 9;
            workDif = maxWork - Workdone;
            if (workDif > 0)
            {
                Sanity -= workDif;
                Reputation -= workDif;
                Money -= workDif;
            }
            maxWork += 5;
            Workdone = 0;
            checkGameStat();
        }
        else if (Time >= 24)
        {
            Time = 24;
        }
    }
    public void TimeStatusChange()
    {
        if (Time == 9)
        {
            TimeStatus = "Clock In";
        }
        else if (Time <= 17)
        {
            TimeStatus = "Day";
        } else
        {
            TimeStatus = "OverTime";
        }
    }
}
