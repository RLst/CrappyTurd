using TMPro;
using UnityEngine;

namespace Pokoro
{
	//Handles the score, score UI and topscore
	public class Score : MonoBehaviour
	{
		//! go through the basics of UI, canvases, images, buttons, etc
		[SerializeField] TextMeshProUGUI scoreText;
		[SerializeField] TextMeshProUGUI topScoreText;

		int score;

		void Start()
		{
			score = 0;
			scoreText.text = score.ToString();
			topScoreText.text = "Hi-Score: " + PlayerPrefs.GetInt("hiscore", 0);
		}

		public void UpdateHiScore()
		{
			//! Explain player prefs; Why you should use them, why you shouldn't
			if (PlayerPrefs.GetInt("hiscore", 0) < score)
			{
				PlayerPrefs.SetInt("hiscore", score);
				PlayerPrefs.Save();
				topScoreText.text = "Hi-Score: " + score;
			}
		}

		//! Explain OnTriggers
		void OnTriggerExit2D(Collider2D other)
		{
			if (!other.GetComponent<Pipes>())
				return;

			score++;
			scoreText.text = score.ToString();
		}
	}
}