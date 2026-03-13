using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    [SerializeField] GameObject ButtonBase;
    [SerializeField] GameObject TriggerThis;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(clip);
        if (TriggerThis != null) 
        {
            TriggerThis.SetActive(true);
        }
        ButtonBase.SetActive(true);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
