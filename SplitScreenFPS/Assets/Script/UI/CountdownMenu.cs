using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownMenu : MonoBehaviour
{
    public int time = 5;

    public TMP_Text counterText;
    public TMP_Text versusText;

    public AudioClip talkCountSound;

    public float sceneLoadDelay = 2;

    public PlayerData player1Data;
    public PlayerData player2Data;

    int counter;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        counter = time;

        audioSource.PlayOneShot(talkCountSound);

        StartCoroutine(Counter());
    }
    IEnumerator Counter()
    {
        while (true)
        {
            counterText.text = counter.ToString();

            counter--;

            if (counter < 0)
            {
                counterText.gameObject.SetActive(false);
                versusText.text = player1Data.nickName + " vs " + player2Data.nickName;
                versusText.gameObject.SetActive(true);

                break;
            }

            yield return new WaitForSeconds(1);
        }
        Invoke("Close", sceneLoadDelay);
    }
    void Close()
    {
        gameObject.SetActive(false);
    }
}
