using UnityEngine;
using UnityEngine.SceneManagement;

public class BolumSec : MonoBehaviour
{
   public void Bolum1()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(1); // Ana menü sahnesinin build indeksi 0 olacak şekilde ayarlanmalıdır.
}public void Bolum2()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(3); // Ana menü sahnesinin build indeksi 0 olacak şekilde ayarlanmalıdır.
}
}
