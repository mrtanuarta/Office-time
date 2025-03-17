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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [Header("Text")]
    [SerializeField] public TextMeshProUGUI TitleText;
    [SerializeField] public TextMeshProUGUI DescriptionText;
    [SerializeField] public TextMeshProUGUI LeftText;
    [SerializeField] public TextMeshProUGUI RightText;
    [SerializeField] public Image image;
    [Header("UI Bar")]
    [SerializeField] public TextMeshProUGUI TimeText;
    [SerializeField] public GameObject Middle;
    [Header("Stat Bars")]  // New Stat Bars
    [SerializeField] public Image SanityBar;
    [SerializeField] public Image ReputationBar;
    [SerializeField] public Image MoneyBar;
    [SerializeField] public Image WorkBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TitleText.text = CardManager.Instance.currCard.eventName;
        DescriptionText.text = CardManager.Instance.currCard.eventDescription;
        LeftText.text = CardManager.Instance.currCard.leftDescription;
        RightText.text = CardManager.Instance.currCard.rightDescription;
        image.sprite = CardManager.Instance.currCard.eventImage;
        TimeText.text = "Day "+(GameManager.Instance.Day).ToString()+", "+(GameManager.Instance.Time).ToString() + ":00";

        UpdateStatBars();
    }

    void UpdateStatBars()
    {
        float maxSanity = 100f;
        float maxReputation = 100f;
        float maxMoney = 100f;
        float maxWork = 100f;

        float sanityTarget = Mathf.Clamp(GameManager.Instance.Sanity / maxSanity, 0f, 1f);
        float reputationTarget = Mathf.Clamp(GameManager.Instance.Reputation / maxReputation, 0f, 1f);
        float moneyTarget = Mathf.Clamp(GameManager.Instance.Money / maxMoney, 0f, 1f);
        float workTarget = Mathf.Clamp(GameManager.Instance.Workdone / maxWork, 0f, 1f);

        SanityBar.fillAmount = Mathf.Lerp(SanityBar.fillAmount, sanityTarget, Time.deltaTime * 5f);
        ReputationBar.fillAmount = Mathf.Lerp(ReputationBar.fillAmount, reputationTarget, Time.deltaTime * 5f);
        MoneyBar.fillAmount = Mathf.Lerp(MoneyBar.fillAmount, moneyTarget, Time.deltaTime * 5f);
        WorkBar.fillAmount = Mathf.Lerp(WorkBar.fillAmount, workTarget, Time.deltaTime * 5f);
    }
}
