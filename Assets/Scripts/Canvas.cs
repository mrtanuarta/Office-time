using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Canvas : MonoBehaviour
{
    public TextMeshProUGUI Best;
    void Update()
    {
        Best.text = "Personal Best (Day): "+AudioManager.Instance.PersonalBest.ToString();
    }
}
