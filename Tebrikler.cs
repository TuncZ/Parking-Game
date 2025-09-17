using UnityEngine;
using UnityEngine.SceneManagement;

public class Tebrikler : MonoBehaviour
{
    // Yeniden başlatma işlemi için çağrılacak fonksiyon
    public void RestartGame()
    {
        // Aktif sahneyi yeniden yükle
        SceneManager.LoadScene(0);
    }

    // Oyundan çıkma işlemi için çağrılacak fonksiyon
    public void QuitGame()
    {
        // Oyunu kapat
        Application.Quit();
    }
}
