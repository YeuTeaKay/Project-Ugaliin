using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class EndCredits : MonoBehaviour
{

    [SerializeField] private GameObject statsPage;
    [SerializeField] private TextMeshProUGUI goodChoicesText;
    [SerializeField] private TextMeshProUGUI badChoicesText;
    [SerializeField] private TextMeshProUGUI genderText;
    [SerializeField] private TextMeshProUGUI endingText;

    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        GameData data = DataPersistenceManager.instance.GetGameData();
        if (data != null && data.EndGame)
        {
            ShowVideo();
        }
        else
        {
            ShowStatsPage();
        }
    }

    private void ShowVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned.");
            ShowStatsPage(); // Fallback to show stats page if no video player is assigned
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoFinished; // Unsubscribe from the event
        ShowStatsPage();
    }

    public void ShowStatsPage()
    {
        GameData data = DataPersistenceManager.instance.GetGameData();
        if (data != null)
        {
            UpdateStatsPage(data);
            statsPage.SetActive(true);
        }
    }
    // Start is called before the first frame update
    public void HideStatsPage()
    {
        statsPage.SetActive(false);
    }

    private void UpdateStatsPage(GameData data)
    {
            goodChoicesText.text = "Good Choices Picked: " + data.goodChoicesCounter;
            badChoicesText.text = "Bad Choices Picked: " + data.badChoicesCounter;
            genderText.text = "Gender: " + data.playerGender;
            endingText.text = "Ending: " + data.Ending;
    }
}
