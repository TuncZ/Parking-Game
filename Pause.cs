using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public ArabaControl arabaControl; // ArabaControl scriptine erişim

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

 public void Restart()
{
    PlayerPrefs.DeleteKey("arabaPozisyonuX"); // Başlangıç pozisyonunu sıfırla
    PlayerPrefs.DeleteKey("arabaPozisyonuY");
    PlayerPrefs.DeleteKey("arabaPozisyonuZ");
    PlayerPrefs.DeleteKey("arabaRotasyonuX");
    PlayerPrefs.DeleteKey("arabaRotasyonuY");
    PlayerPrefs.DeleteKey("arabaRotasyonuZ");

    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
public void ReturnToMainMenu()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(0); // Ana menü sahnesinin build indeksi 0 olacak şekilde ayarlanmalıdır.
}


    public void QuitGame()
    {
        Application.Quit();
    }

 public void SaveGame()
{
    arabaControl.Kaydet();
    PlayerPrefs.SetString("lastSavedScene", SceneManager.GetActiveScene().name); // Son kaydedilen sahne adını kaydet

    // Arabanın konumunu ve rotasyonunu kaydet
    PlayerPrefs.SetFloat("arabaPozisyonuX", arabaControl.transform.position.x);
    PlayerPrefs.SetFloat("arabaPozisyonuY", arabaControl.transform.position.y);
    PlayerPrefs.SetFloat("arabaPozisyonuZ", arabaControl.transform.position.z);
    PlayerPrefs.SetFloat("arabaRotasyonuX", arabaControl.transform.rotation.eulerAngles.x);
    PlayerPrefs.SetFloat("arabaRotasyonuY", arabaControl.transform.rotation.eulerAngles.y);
    PlayerPrefs.SetFloat("arabaRotasyonuZ", arabaControl.transform.rotation.eulerAngles.z);
}



}
