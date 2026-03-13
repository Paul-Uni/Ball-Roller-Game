using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    [SerializeField] string Levelname;

    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip pressedSound;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
    }

    public void SelectLevel()
    {
        StartCoroutine(SelectLevelDelay());
    }

    public void hoverLevel()
    {
        audioSource.PlayOneShot(hoverSound);
    }

    IEnumerator SelectLevelDelay()
    {
        audioSource.PlayOneShot(pressedSound);
        yield return new WaitForSeconds(pressedSound.length);
        SceneManager.LoadScene(Levelname);
    }
}
