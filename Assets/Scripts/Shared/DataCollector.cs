using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCollector : MonoBehaviour{

	public Text textTimer;
	public Text textHitCount;
	public Text textMissCount;
	public Text textCurrentMinuteCount;
	public Text textPerMinuteAverage;
	public Text textGoalReached;

	private float gameTimer = 0.0f;
	private int seconds;
	private int minutes;
	private int hours;

	private int hitCount = 0;
	private int missCount = 0;

	private List<int> minuteAverages = new List<int>();
	private int currentMinuteCount = 0;
	private float hitAveragePerMinute = 0;
	private int goalReachedCount = 0;

	private float calculationDelay = 1.0f;

	private void Update()
	{
		updateTimer();


		if (gameTimer > calculationDelay)
		{
			if (seconds == 0)
			{
				CalculatePerMinuteAverage();
			}

			calculationDelay = gameTimer + 1;
		}


		updateDisplay();
	}

	public void increaseHit()
	{
		hitCount++;
		currentMinuteCount++;
	}

	public void increaseGoalReached()
	{
		goalReachedCount++;
	}

	public void increaseMiss()
	{
		if (gameTimer > calculationDelay)
		{ 
			missCount++;
			calculationDelay = gameTimer + 1;
		}
	}

	public void CalculatePerMinuteAverage()
	{
		minuteAverages.Add(currentMinuteCount);
		currentMinuteCount = 0;
		int total = 0;

		foreach (int value in minuteAverages)
		{
			total += value;
		}

		hitAveragePerMinute = (float) total / minuteAverages.Count;
	}

	public void updateTimer()
	{
		gameTimer += Time.deltaTime;
		seconds = (int)(gameTimer % 60);
		minutes = (int)(gameTimer / 60) % 60;
		hours = (int)(gameTimer / 3600) % 24;
	}

	public void updateDisplay()
	{
		textTimer.text = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
		textHitCount.text = string.Format("{0:00000}", hitCount);
		textMissCount.text = string.Format("{0:0000}", missCount);
		textCurrentMinuteCount.text = string.Format("{0:0000}", currentMinuteCount);
		textPerMinuteAverage.text = string.Format("{0:0000.00}", hitAveragePerMinute);
		textGoalReached.text = string.Format("{0:0000}", goalReachedCount);
}
}
