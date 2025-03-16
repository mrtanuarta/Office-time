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
    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private TextMeshProUGUI LeftText;
    [SerializeField] private TextMeshProUGUI RightText;
    [SerializeField] private Image image;
    private Texture eventImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TitleText.text = CardManager.Instance.currCard.eventName;
        DescriptionText.text = CardManager.Instance.currCard.eventDescription;
        LeftText.text = TitleText.text = CardManager.Instance.currCard.leftDescription;
        RightText.text = CardManager.Instance.currCard.rightDescription;
        image.sprite = CardManager.Instance.currCard.eventImage;
    }
}
