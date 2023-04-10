using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Pokoro
{
	//! Make sure I use my good voice

	//Controls pipe spawning
	//Checks if bird is dead
	//Handles game over logic
	public class Game : MonoBehaviour
	{
		public Bird bird;
		public GameObject gameOverScreen;

		[Header("Pipes")]
		public GameObject pipes;
		public Transform pipeSpawnPoint;
		public float pipeSpawnDelay = 1f;

		[Space]
		public UnityEvent onGameOver;

		void Start()
		{
			//Disable cursor
			Cursor.visible = false;

			//Disable gameover screen
			gameOverScreen.SetActive(false);

			//Unpause
			Time.timeScale = 1f;

			//! Tutorial: Turn this into a Start Coroutine
			InvokeRepeating(nameof(SpawnPipes), 0f, pipeSpawnDelay);
		}

		//! Maybe do all logic inside the main Update function first.
		//! Explain why we should split procedures into methods:
		//! • Because it allows you to organize and outline and name your logic
		//! • It allows the logic to be invoked from anywhere
		//! •
		void SpawnPipes()
		{
			// print("Spawn");

			Instantiate(pipes, pipeSpawnPoint.position, pipeSpawnPoint.rotation);
		}

		//! Explain what the Update() message does: Update runs every frame in a loop, Unity even loop diagram + animations
		void Update()
		{
			//! Explain the importance of comments
			//! • You will forget what the code does you come back. This helps reduce time
			//! • Especially important when working in a team with other programmers and developers
			//! • Alternatives: Self-commenting code; name your variables and symbols clearly. Don't use dumb names like a/b/c... except during foreach loops etc
			//Check if the bird has died or not
			if (bird.isDead)
			{
				GameOver();
			}

			//Check for quit button
			if (Input.GetKeyDown(KeyCode.Escape))
				Quit();
		}

		void GameOver()
		{
			onGameOver.Invoke();
#if UNITY_IOS
			Cursor.visible = true;
#endif
			Time.timeScale = 0;

			ShowGameOverScreen();

			if (Input.anyKeyDown)
			{
				RestartGame();
			}
		}

		void ShowGameOverScreen()
		{
			//Enable gameover screen
			gameOverScreen.SetActive(true);
		}

		//Accessed using a button on the game over screen
		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		public void Quit()
		{
			Application.Quit();
		}
	}
}