using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Don't forget to add this for SceneManager

public class ArabaControl : MonoBehaviour
{
    AudioSource audioSource;
    public WheelCollider Wheel_FlCol;
    public WheelCollider Wheel_FrCol;
    public WheelCollider Wheel_BlCol;
    public WheelCollider Wheel_BrCol;

    public GameObject Wheel_Fl;
    public GameObject Wheel_Fr;
    public GameObject Wheel_Bl;
    public GameObject Wheel_Br;

    public float maxMotorGucu;
    public float maxDonusAcisi;
    public float motor;
    public float hiz_ayari;
    public float firengucu;

    public bool kontak;
    public float speed;
    private Rigidbody _rb;

    // New variables for area detection
    public float areaTimeLimit = 4f;
    private float areaTimer = 0f;
    private bool isInsideArea = false;

  void Start()
{
    _rb = GetComponent<Rigidbody>();  
    audioSource = GetComponent<AudioSource>();

    // Eğer kaydedilmiş bir pozisyon varsa ve şu anki sahne bölüm 1 ise
    if (PlayerPrefs.HasKey("arabaPozisyonuX") && SceneManager.GetActiveScene().buildIndex == 1)
    {
        float x = PlayerPrefs.GetFloat("arabaPozisyonuX");
        float y = PlayerPrefs.GetFloat("arabaPozisyonuY");
        float z = PlayerPrefs.GetFloat("arabaPozisyonuZ");
        Vector3 arabaPozisyonu = new Vector3(x, y, z);
        Quaternion arabaRotasyonu = Quaternion.Euler(
            PlayerPrefs.GetFloat("arabaRotasyonuX"),
            PlayerPrefs.GetFloat("arabaRotasyonuY"),
            PlayerPrefs.GetFloat("arabaRotasyonuZ")
        );
        transform.position = arabaPozisyonu;
        transform.rotation = arabaRotasyonu;
    }
    else if (PlayerPrefs.HasKey("arabaPozisyonuX") && SceneManager.GetActiveScene().buildIndex == 2)
    {
        // Eğer kaydedilmiş bir pozisyon varsa ve şu anki sahne bölüm 3 ise
        float x = PlayerPrefs.GetFloat("arabaPozisyonuX");
        float y = PlayerPrefs.GetFloat("arabaPozisyonuY");
        float z = PlayerPrefs.GetFloat("arabaPozisyonuZ");
        Vector3 arabaPozisyonu = new Vector3(x, y, z);
        Quaternion arabaRotasyonu = Quaternion.Euler(
            PlayerPrefs.GetFloat("arabaRotasyonuX"),
            PlayerPrefs.GetFloat("arabaRotasyonuY"),
            PlayerPrefs.GetFloat("arabaRotasyonuZ")
        );
        transform.position = arabaPozisyonu;
        transform.rotation = arabaRotasyonu;
    }
    else
    {
        // Kaydedilmiş bir pozisyon yoksa ya da sahne farklı bir sahneyse başlangıç pozisyonunu belirtin, örneğin:
        Vector3 baslangicPozisyonu = new Vector3(5f, 0f, 2f);
        Quaternion baslangicRotasyonu = Quaternion.identity; // Başlangıç rotasyonu

        transform.position = baslangicPozisyonu;
        transform.rotation = baslangicRotasyonu;
    }
}


    public void Kaydet()
    {
        PlayerPrefs.SetFloat("arabaPozisyonuX", transform.position.x);
        PlayerPrefs.SetFloat("arabaPozisyonuY", transform.position.y);
        PlayerPrefs.SetFloat("arabaPozisyonuZ", transform.position.z);
        PlayerPrefs.SetFloat("arabaRotasyonuX", transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("arabaRotasyonuY", transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("arabaRotasyonuZ", transform.rotation.eulerAngles.z);
        PlayerPrefs.Save();
    }

   void FixedUpdate()
{
    if (isInsideArea && Input.GetKeyDown(KeyCode.P))
    {
        Debug.Log("Tebrikler!");
        areaTimer = 0f;
        PlayerPrefs.SetString("lastSavedScene", SceneManager.GetActiveScene().name); // Son kaydedilen sahne adını kaydet
        SceneManager.LoadScene(3); // Sonraki sahneyi yükle
    }
    else
    {
        areaTimer = 0f;
    }

    // Diğer kodlar buraya taşınacak...
    // ...

    if (Input.GetKeyDown(KeyCode.Tab)) kontak = !kontak;

    if (kontak)
    {
        speed = _rb.velocity.magnitude * hiz_ayari;
        motor = maxMotorGucu * Input.GetAxis("Vertical");
        float donus = maxDonusAcisi * Input.GetAxis("Horizontal");
        float firenTorku = firengucu * Mathf.Abs(Input.GetAxis("Jump"));

        if (firenTorku < 0.005f)
        {
            Wheel_BrCol.motorTorque = motor;
            Wheel_BlCol.motorTorque = motor;
            Wheel_BrCol.brakeTorque = 0;
            Wheel_BlCol.brakeTorque = 0;
        }
        else
        {
            Wheel_BrCol.brakeTorque = firenTorku;
            Wheel_BlCol.brakeTorque = firenTorku;
        }

        Wheel_FlCol.steerAngle = Wheel_FrCol.steerAngle = donus;
    }
    else
    {
        motor = 0;
        float donus = maxDonusAcisi * Input.GetAxis("Horizontal");
        float firenTorku = firengucu * Mathf.Abs(Input.GetAxis("Jump"));

        if (firenTorku < 0.005f)
        {
            Wheel_BrCol.motorTorque = motor;
            Wheel_BlCol.motorTorque = motor;
            Wheel_BrCol.brakeTorque = 0;
            Wheel_BlCol.brakeTorque = 0;
        }
        else
        {
            Wheel_BrCol.brakeTorque = firenTorku;
            Wheel_BlCol.brakeTorque = firenTorku;
        }

        Wheel_FlCol.steerAngle = Wheel_FrCol.steerAngle = donus;
    }

    SanalTeker();
}

    void SanalTeker()
    {
        Quaternion rot;
        Vector3 pos;

        Wheel_FlCol.GetWorldPose(out pos, out rot);
        Wheel_Fl.transform.position = pos;
        Wheel_Fl.transform.rotation = rot;

        Wheel_FrCol.GetWorldPose(out pos, out rot);
        Wheel_Fr.transform.position = pos;
        Wheel_Fr.transform.rotation = rot;

        Wheel_BlCol.GetWorldPose(out pos, out rot);
        Wheel_Bl.transform.position = pos;
        Wheel_Bl.transform.rotation = rot;

        Wheel_BrCol.GetWorldPose(out pos, out rot);
        Wheel_Br.transform.position = pos;
        Wheel_Br.transform.rotation = rot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bot")
        {
            Debug.Log("Araca Çarptın!");
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            isInsideArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            isInsideArea = false;
        }
    }
}
