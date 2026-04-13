using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject gameOverPanel;

    // Метод Awake вызывается при инициализации скрипта
    public void Awake()
    {
        // Гарантируем, что при старте уровня панель проигрыша скрыта
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Метод для кнопки перезапуска игры
    public void ReplayGame()
    {
        // Важно: возвращаем время в нормальный режим, 
        // так как при проигрыше мы его останавливали (Time.timeScale = 0)
        Time.timeScale = 1;

        // Загружаем сцену заново (убедись, что имя сцены в Build Settings совпадает)
        SceneManager.LoadScene("Level");
    }

    // Метод для кнопки выхода в главное меню
    public void QuitGame()
    {
        // Перед выходом тоже лучше вернуть время в норму
        Time.timeScale = 1;

        // Загружаем сцену меню
        SceneManager.LoadScene("Menu");
    }

    // Метод для принудительного показа панели (если потребуется вызвать извне)
    public void UnhideGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    // Метод для принудительного скрытия панели
    public void HideGameOverPanel()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
}