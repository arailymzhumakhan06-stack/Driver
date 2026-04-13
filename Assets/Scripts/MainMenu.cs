using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        // Это заставит кнопку работать прямо в редакторе Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        // Это закроет уже скомпилированную игру (.exe)
        Application.Quit();

        // Помогает убедиться в консоли, что код сработал
        Debug.Log("Выход из игры выполнен");
    }
}
