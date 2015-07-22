using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Assets
	public GameObject brickPrefab;

	//Logic
	public int initialBalls;
	int ballsInPlay;
	int ballsPending;
	int currentScore;
	int highScore;

	//Balls
	public GameObject ballSpawnPoint;
	public GameObject ballPrefab;
	public int ballRandomAngle; 

	//UI
	public TextMesh scoreText;
	public TextMesh highScoreText;
	public TextMesh ballsText;

	//Instance
	private static GameManager _instance;
	public static GameManager instance() {
		if (_instance == null) {
			_instance = FindObjectOfType (typeof(GameManager)) as GameManager;
		}
		return _instance;
	}
	
	void Awake () {
		loadValues ();
		createBricks ();
		setTexts ();
	}

	void Update () {
		if (isGameOver ()) {
			Debug.Log("GAME OVER");
		}
	}

	private bool isGameOver() {
		return ballsPending + ballsInPlay <= 0;
	}

	private void loadValues() {
		highScore = PlayerPrefs.GetInt ("HighScore", 0);
		ballsPending = initialBalls;
	}

	private void createBricks() {
		for (int y = 10; y>=4; y--) {
			for (int x = -10; x<=10; x+=2) {
				GameObject brick = (GameObject)Instantiate(brickPrefab, new Vector3(x, y, 2), Quaternion.identity);
				Renderer renderer = brick.GetComponent<Renderer>();
				string path = "Materials/Bricks/"+(Random.Range (0, 4).ToString());
				Material material =  (Material)Resources.Load(path, typeof(Material));
				renderer.material = material;
			}
		}
	}

	private void setTexts() {
		setHighScoreText ();
		setBallsText ();
		setScoreText ();
	}

	public void tryLaunchBall() {
		if (ballsPending > 0) {
			float randomZAngle = UnityEngine.Random.Range(-ballRandomAngle, ballRandomAngle);
			Debug.Log(randomZAngle);
			Instantiate(ballPrefab, ballSpawnPoint.transform.position, Quaternion.Euler(0, 0, randomZAngle));
			ballsPending--;
			ballsInPlay++;
			setBallsText();
		}
	}

	public void destroyBall() {
		if (ballsInPlay > 0) {
			ballsInPlay--;
		}
	}

	private void setHighScoreText() {
		highScoreText.text = "Record: " + highScore;
	}

	private void setBallsText() {
		ballsText.text = "Balls: " + ballsPending;
	}

	private void setScoreText() {
		scoreText.text = "Score: " + currentScore;
	}
}
