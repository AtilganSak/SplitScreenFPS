using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownMenu : MonoBehaviour
{
    public int time = 5;

    public TMP_Text player1_counterText;
    public TMP_Text player1_versusText;

    public TMP_Text player2_counterText;
    public TMP_Text player2_versusText;

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
            player1_counterText.text = counter.ToString();
            player2_counterText.text = counter.ToString();

            counter--;

            if (counter < 0)
            {
                player1_counterText.gameObject.SetActive(false);
                player2_counterText.gameObject.SetActive(false);
                
                player1_versusText.text = player1Data.nickName + " vs " + player2Data.nickName;
                player2_versusText.text = player1Data.nickName + " vs " + player2Data.nickName;

                player1_versusText.gameObject.SetActive(true);
                player2_versusText.gameObject.SetActive(true);

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
