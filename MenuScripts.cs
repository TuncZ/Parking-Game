using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
   public void StartGame()
{
    PlayerPrefs.DeleteKey("arabaPozisyonuX"); // Başlangıç pozisyonunu sıfırla
    PlayerPrefs.DeleteKey("arabaPozisyonuY");
    PlayerPrefs.DeleteKey("arabaPozisyonuZ");
    PlayerPrefs.DeleteKey("arabaRotasyonuX");
    PlayerPrefs.DeleteKey("arabaRotasyonuY");
    PlayerPrefs.DeleteKey("arabaRotasyonuZ");

    SceneManager.LoadScene(1);
}


    public void QuitGame()
    {
        Application.Quit();
    }
public void BolumSec()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(4); // Ana menü sahnesinin build indeksi 0 olacak şekilde ayarlanmalıdır.
}
   public void LoadGame()
{
    if (PlayerPrefs.HasKey("arabaPozisyonuX"))
    {
        string lastSavedScene = PlayerPrefs.GetString("lastSavedScene", "DefaultSceneName"); // DefaultSceneName yerine yüklenecek varsayılan sahne adını belirtin
        SceneManager.LoadScene(lastSavedScene);
    }
    else
    {
        Debug.Log("No saved game found!");
    }
}

}
