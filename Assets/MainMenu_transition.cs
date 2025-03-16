using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu_transition : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Office-time");
    }
}
