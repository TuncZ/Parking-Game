using UnityEngine;

public class KameraDegistir : MonoBehaviour
{
    public Camera[] carCameras; // Arabanın içerisindeki kamera bileşenleri
    private int currentCameraIndex = 0; // Şu anki kamera indeksi

    void Start()
    {
        // Başlangıçta ilk kamerayı aktif hale getir
        SetActiveCamera(currentCameraIndex);
    }

    void Update()
    {
        // "C" tuşuna basıldığında kamera pozisyonunu değiştir
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= carCameras.Length)
            {
                currentCameraIndex = 0;
            }
            SetActiveCamera(currentCameraIndex);
        }
    }

    void SetActiveCamera(int index)
    {
        // Tüm kameraları devre dışı bırak
        foreach (Camera cam in carCameras)
        {
            cam.enabled = false;
        }

        // Seçilen kamerayı aktif hale getir
        carCameras[index].enabled = true;
        carCameras[index].gameObject.SetActive(true);

        // Diğer kameraları devre dışı bırak
        for (int i = 0; i < carCameras.Length; i++)
        {
            if (i != index)
            {
                carCameras[i].gameObject.SetActive(false);
            }
        }
    }
}