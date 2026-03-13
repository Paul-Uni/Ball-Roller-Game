using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] int x;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;


    private void Start()
    {

    }
    // Start is called before the first frame update
    public void changeSkin()
    {
        PlayerPrefs.SetInt("PlayerMaterial", x);
        audioSource.PlayOneShot(audioClip);
    }
}
