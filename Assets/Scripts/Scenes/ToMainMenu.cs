using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene("Main-menu"); // Ensure "Main-menu" is in Build Settings
    }
}
