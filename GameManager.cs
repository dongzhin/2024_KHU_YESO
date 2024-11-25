using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameScreenPanel;

    [SerializeField]
    private GameObject mainMenuPanel;

    [SerializeField]
    private GameObject timeOverPanel;

    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private TextMeshProUGUI yourScore;

    private int score = 0;

    [SerializeField]
    private int timerSet;
    public int timer;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    
    public void IncreaseScore() {
        if (Burning.instance.curVal > 70){
            score += 1;
        }
        score += 1;
        scoreText.SetText(score.ToString());
        Burning.instance.IncreaseVal();
    }

    public void DecreaseTimer() {
        timer -= 1;
        timerText.SetText(timer.ToString());
    }

    public void OnClickStart() {
        mainMenuPanel.SetActive(false); // 메인화면 숨김
        gameScreenPanel.SetActive(true); // 게임화면 보임
        score = 0;
        scoreText.SetText(score.ToString()); // SCORE값으로 점수text 초기화
        timer = timerSet; // 타이머 초기화
        Burning.instance.curVal = 0; // 버닝 값 변수 초기화
        Burning.instance.burningBar.value = 0; // 버닝 게이지 초기화
    }

    public void TimeOverPanel() {
        gameScreenPanel.SetActive(false);
        timeOverPanel.SetActive(true);
        yourScore.SetText(score.ToString());
        Debug.Log("timeover!");
        Debug.Log("Received college: " + DataReceiver.instance.College);
        Debug.Log("Received major: " + DataReceiver.instance.Major);
        Debug.Log("Received name: " + DataReceiver.instance.Name);
        Sender();
    }

    public void PlayAgain() {
        timeOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    private string serverUrl = "https://hyunverse.kro.kr:3001/sendResult";
    
    public void Sender() {
        DataSender dataSender = gameObject.AddComponent<DataSender>();
        
        DataSender.UserInfo userInfo = new DataSender.UserInfo
        {
            gameCode = 5,
            score = score
        };
        
        // 데이터 전송
        dataSender.SendDataToServer(serverUrl, userInfo);
    }
}
