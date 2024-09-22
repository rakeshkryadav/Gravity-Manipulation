using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWon;
    [SerializeField] private GameObject pauseMenu;
    private float currentTime = 120;
    public int points = 0;
    public bool isGameOver = false;
    private bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        // Hide the banners.
        gameOver.SetActive(false);
        gameWon.SetActive(false);
        pauseMenu.SetActive(false);
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
        if((points < 5 && currentTime <= 1) || isGameOver){
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        // Game Won if all the points collected within the time limit.
        else if(points == 5 && currentTime > 1){
            gameWon.SetActive(true);
            Time.timeScale = 0f;
        }

        // Pause Menu.
        if(Input.GetKeyDown(KeyCode.Escape) && isPause == false){
            isPause = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause){
            isPause = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // show points.
        pointsText.text = points + "/5";
    }

    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Exit(){
        Application.Quit();
    }
}
