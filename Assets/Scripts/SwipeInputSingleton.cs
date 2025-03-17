using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

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

    private bool canClick = true;
    private void Update()
    {
        if (GameManager.Instance.GameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                UIManager.Instance.GetComponent<ToMainMenu>().GoToMainMenu();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && canClick)
            {
                canClick = false;
                UIManager.Instance.LeftText.GetComponent<Animator>().SetTrigger("PickLeft");
                UIManager.Instance.Middle.GetComponent<Animator>().SetTrigger("Left");
                CardManager.Instance.pickLeft();
                StartCoroutine(ClickCooldown());
                AudioManager.Instance.PlaySFX(AudioManager.Instance.swooshSFX);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && canClick)
            {
                canClick = false;
                UIManager.Instance.RightText.GetComponent<Animator>().SetTrigger("PickRight");
                UIManager.Instance.Middle.GetComponent<Animator>().SetTrigger("Right");
                CardManager.Instance.pickRight();
                StartCoroutine(ClickCooldown());
                AudioManager.Instance.PlaySFX(AudioManager.Instance.swooshSFX);
            }
        } else {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && canClick)
            {
                UIManager.Instance.GetComponent<ToMainMenu>().GoToMainMenu();
            } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && canClick)
            {
                UIManager.Instance.GetComponent<ToMainMenu>().GoToMainMenu();
            }
        }
    }

    private void ProcessInput(string direction)
    {
        Debug.Log("Player chose: " + direction);
        // Add logic here to handle the choice in the game.
    }
    private IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canClick = true;
        if (!GameManager.Instance.GameOver){
            CardManager.Instance.PickNewCard();
        }
    }
}

