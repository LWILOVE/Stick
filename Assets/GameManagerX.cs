using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerX : MonoBehaviour
{
    private Transform startPoint;
    private Transform spawnPoint;
    public GameObject pinPrefab;
    private Pin currentPin;
    private bool isGameOver = false;
    private int score = 0;
    public Text scoreText;
    private Camera mainCamera;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPin();
        scoreText = GameObject.Find("ScoreShow").GetComponent<Text>();
        //获取主相机
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        if (Input.GetMouseButtonDown(0))
        {
            currentPin.StartFly();
            SpawnPin();
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void SpawnPin()
    {
        currentPin = GameObject.Instantiate(pinPrefab,pinPrefab.transform.position,pinPrefab.transform.rotation).GetComponent<Pin>();
    }
    //判断游戏失败
    public void GameOver()
    {
        if (isGameOver) return;
        //停止小球旋转    
        GameObject.Find("CircleX").GetComponent<CircleRot>().enabled = false;
        isGameOver = true;
        StartCoroutine(GameoverAnimation());
    }
    //制作结局动画
    IEnumerator GameoverAnimation()
    {
        while(true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor,Color.red ,speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize,4,speed*Time.deltaTime);
            if (Mathf.Abs(mainCamera.orthographicSize - 4) < 0.01f)
            {
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        //0.3S后重开
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
