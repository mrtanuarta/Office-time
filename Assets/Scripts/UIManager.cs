using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

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
    [Header("Text")]
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;
    public Image image;
    [Header("UI Bar")]
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI StatusText;
    public GameObject Middle;
    public TextMeshProUGUI WorkDoneText;

    [Header("Stat Bars")]  // New Stat Bars
    public Image SanityBar;
    public Image ReputationBar;
    public Image MoneyBar;
    public Image WorkBar;
    [Header("Day/Night Transition")]
    [SerializeField] private Image nightImage;  
    private int transitionStartTime = 17; 
    private int transitionEndTime = 20;
    [Header("PlayerProfile")]
    [SerializeField] private Image PlayerPicture;
    [SerializeField] private Sprite basePlayer;
    [SerializeField] private Sprite tiredPlayer;
    [SerializeField] private Sprite stressPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        UpdateStatBars();
        UpdateDayNightTransition();
        updatePlayerProfile();
    }

    void UpdateUI()
    {
        TitleText.text = CardManager.Instance.currCard.eventName;
        DescriptionText.text = CardManager.Instance.currCard.eventDescription;
        LeftText.text = CardManager.Instance.currCard.leftDescription;
        RightText.text = CardManager.Instance.currCard.rightDescription;
        image.sprite = CardManager.Instance.currCard.eventImage;
        TimeText.text = (GameManager.Instance.Time).ToString() + ":00";
        DayText.text = (GameManager.Instance.Day).ToString();
        StatusText.text = GameManager.Instance.TimeStatus;
        WorkDoneText.text = GameManager.Instance.Workdone.ToString()+"/"+GameManager.Instance.maxWork.ToString();
    }

    void UpdateStatBars()
    {
        float maxSanity = 100f;
        float maxReputation = 100f;
        float maxMoney = 100f;

        float sanityTarget = Mathf.Clamp(GameManager.Instance.Sanity / maxSanity, 0f, 1f);
        float reputationTarget = Mathf.Clamp(GameManager.Instance.Reputation / maxReputation, 0f, 1f);
        float moneyTarget = Mathf.Clamp(GameManager.Instance.Money / maxMoney, 0f, 1f);
        float workTarget = Mathf.Clamp(GameManager.Instance.Workdone / GameManager.Instance.maxWork, 0f, 1f);

        SanityBar.fillAmount = Mathf.Lerp(SanityBar.fillAmount, sanityTarget, Time.deltaTime * 5f);
        ReputationBar.fillAmount = Mathf.Lerp(ReputationBar.fillAmount, reputationTarget, Time.deltaTime * 5f);
        MoneyBar.fillAmount = Mathf.Lerp(MoneyBar.fillAmount, moneyTarget, Time.deltaTime * 5f);
        WorkBar.fillAmount = Mathf.Lerp(WorkBar.fillAmount, workTarget, Time.deltaTime * 5f);
    }

    void UpdateDayNightTransition()
    {
        int currentTime = GameManager.Instance.Time;  

        if (currentTime >= transitionStartTime && currentTime <= transitionEndTime)
        {
            float progress = Mathf.InverseLerp(transitionStartTime, transitionEndTime, currentTime);
            Color newColor = nightImage.color;
            newColor.a = progress;  
            nightImage.color = newColor;
        }
        else if (currentTime < transitionStartTime)
        {
            Color newColor = nightImage.color;
            newColor.a = 0f;
            nightImage.color = newColor;
        }
        else if (currentTime > transitionEndTime)
        {
            Color newColor = nightImage.color;
            newColor.a = 1f;
            nightImage.color = newColor;
        }
    }
    void updatePlayerProfile()
    {
        float sanity = GameManager.Instance.Sanity;
        float reputation = GameManager.Instance.Reputation;
        float money = GameManager.Instance.Money;
        if (sanity <= 20 || reputation <= 20 || money <= 20)
        {
            PlayerPicture.sprite = stressPlayer;
        }
        else if (sanity <= 40 || reputation <= 40 || money <= 40)
        {
            PlayerPicture.sprite = tiredPlayer;
        }
        else
        {
            PlayerPicture.sprite = basePlayer;
        }
    }
}
