using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

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
    private void Update()
    {
        if (GameManager.Instance.GameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                ProcessInput("Left");
                CardManager.Instance.pickLeft();
                CardManager.Instance.PickNewCard();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                ProcessInput("Right");
                CardManager.Instance.pickRight();
                CardManager.Instance.PickNewCard();
            }
        }
    }

    private void ProcessInput(string direction)
    {
        Debug.Log("Player chose: " + direction);
        // Add logic here to handle the choice in the game.
    }
}
