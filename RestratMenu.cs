using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject pauseMenu;
    public float timeLimit = 0f; // Kullanıcı tarafından belirlenecek zaman sınırı
    private float currentTime = 0f; // Geçen süreyi takip etmek için kullanılacak

    void Update()
    {
        // Zaman sınırına ulaşıldığında pause menüsünü etkinleştir
        if (currentTime >= timeLimit && !IsPaused)
        {
            PauseGame();
        }
        else
        {
            currentTime += Time.deltaTime; // Zamanı güncelle
        }

        
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void RestartGame()
    {
        // Aktif olan sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Oyun zaman ölçeğini tekrar 1'e ayarla
        Time.timeScale = 1f;
        // Oyunu duraklatma durumunu sıfırla
        IsPaused = false;
        // Zaman sayacını sıfırla
        currentTime = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
