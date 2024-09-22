using UnityEngine;
using TMPro;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWon;
    private float currentTime = 120;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Hide the banners.
        gameOver.SetActive(false);
        gameWon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 1){
            // deduct time by 1 per second.
            currentTime -= Time.deltaTime;

            // convert time into 00min : 00sec format.
            timer.text = (Mathf.FloorToInt(currentTime) / 60).ToString("00") + ":" + (Mathf.FloorToInt(currentTime) % 60).ToString("00");
        }

        // Game Over if time is over and not all points are collected.
        if(points < 5 && currentTime <= 1){
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        // Game Won if all the points collected within the time limit.
        else if(points == 5 && currentTime > 1){
            gameWon.SetActive(true);
        }

        // show points.
        pointsText.text = points + "/5";
    }
}
