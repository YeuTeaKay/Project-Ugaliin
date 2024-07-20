using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using SimpleAudioManager;
using TMPro;

public class EndCredits : MonoBehaviour
{

    [SerializeField] private GameObject statsPage;
    [SerializeField] private GameObject videoPage;
    [SerializeField] private GameObject screenPage;
    [SerializeField] private GameObject EndGameButton;
    [SerializeField] private TextMeshProUGUI goodChoicesText;
    [SerializeField] private TextMeshProUGUI badChoicesText;
    [SerializeField] private TextMeshProUGUI genderText;
    [SerializeField] private TextMeshProUGUI endingText;

    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        statsPage.SetActive(false);
        EndGameButton.SetActive(false);
        videoPage.SetActive(false);
        screenPage.SetActive(false);

    }

    private void Update()
    {
        GameData data = DataPersistenceManager.instance.GetGameData();
        if (data.EndGame == true)
        {
            ShowVideo();
            screenPage.SetActive(true);
            videoPage.SetActive(true);
        }
 
        UpdateStatsPage(data);

    }

    private void ShowVideo()
    {
            Manager.instance.PlaySong(2);
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoFinished;// Unsubscribe from the event
        ShowStatsPage();
    }

    public void ShowStatsPage()
    {
        screenPage.SetActive(false);
        videoPage.SetActive(false);
        GameData data = DataPersistenceManager.instance.GetGameData();
        UpdateStatsPage(data);
        statsPage.SetActive(true);
        StartCoroutine(NextSceneButton());
            
    }
    // Start is called before the first frame update

    private IEnumerator NextSceneButton()
    {  

        yield return new WaitForSeconds(10f);
        EndGameButton.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void UpdateStatsPage(GameData data)
    {
            goodChoicesText.text = "Good Choices Picked: " + data.goodChoicesCounter;
            badChoicesText.text = "Bad Choices Picked: " + data.badChoicesCounter;
            genderText.text = "Gender: " + data.playerGender;
            endingText.text = "Ending: " + data.Ending;
    }
}
