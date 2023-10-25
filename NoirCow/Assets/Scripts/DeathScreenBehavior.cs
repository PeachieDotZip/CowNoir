/*****************************************************************************
// File Name :         DeathScreenBehavior.cs
// Author :            Lorien Nergard
// Creation Date :     October 16th, 2023
//
// Brief Description : Controls the buttons that appear when the player dies
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenBehavior : MonoBehaviour
{
    /// <summary>
    /// Quits the game
    /// </summary>
<<<<<<< Updated upstream
    public void exitGame()
=======
<<<<<<< HEAD
    public void ExitGame()
=======
    public void exitGame()
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes
    {
        Application.Quit();
    }

    /// <summary>
    /// Goes to main menu
    /// </summary>
<<<<<<< Updated upstream
    public void mainMenu()
=======
<<<<<<< HEAD
    public void MainMenu()
=======
    public void mainMenu()
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene("Main Menu");
    }

    /// <summary>
    /// Restarts game
    /// </summary>
<<<<<<< Updated upstream
    public void restart()
=======
<<<<<<< HEAD
    public void Restart()
=======
    public void restart()
>>>>>>> 6c1f16f42df958120d324e2bed590807675137c6
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
