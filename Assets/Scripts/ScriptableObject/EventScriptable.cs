using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObject/Event")]
public class EventScriptable : ScriptableObject
{
    [Header("UI Related")]
    public Sprite eventImage;
    public string eventName;
    public string eventDescription;
    [Header("Swipe Left")]
    public string leftDescription;
    public float leftSanity;
    public float leftReputation;
    public float leftMoney;
    public float leftWorkdone;
    public int leftTimeSpent;
    [Header("Swipe Right")]
    public string rightDescription;
    public float rightSanity;
    public float rightReputation;
    public float rightMoney;
    public float rightWorkdone;
    public int rightTimeSpent;
    [Header("Spawn Related")]
    public float weight;
}
