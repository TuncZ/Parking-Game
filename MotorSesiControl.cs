using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSesiControl : MonoBehaviour
{
    public AudioClip acilis;
    public AudioClip calisma;
    public AudioClip kapanis;

public float du_hiz;
public float mi_pit;
public float pi_hiz;
    private AudioSource _source;
bool kontak;
float hiz;
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
{
    kontak = GetComponent<ArabaControl2>().kontak;
    hiz = GetComponent<ArabaControl2>().speed;

    if (!kontak && _source.clip == calisma)
    {
        _source.clip = kapanis;
        _source.Play();
    }
    if (kontak && (_source.clip == kapanis || _source.clip == null))
    {
        _source.clip = acilis;
        _source.Play();
        _source.pitch = 1;
    }
    if (kontak && !_source.isPlaying)
    {
        _source.clip = acilis;
        _source.Play();
    }
    if (_source.clip == calisma)
    {
        _source.pitch = Mathf.Lerp(_source.pitch, mi_pit + Mathf.Abs(hiz) / du_hiz, pi_hiz);
    }
}

}
