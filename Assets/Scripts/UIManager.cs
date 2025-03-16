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
    }
}
