using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using System.IO;


/// <summary>
/// Collected Data About Perfomance
/// </summary>
public class DataCollector : MonoBehaviour{

	/// <summary>
	/// On/Off To recored the data To File
	/// </summary>
	public bool recoredData;

	/// <summary>
	/// Display results to secreen
	/// </summary>
	public Text textTimer;
	public Text textHitCount;
	public Text textMissCount;
	public Text textCurrentMinuteCount;
	public Text textPerMinuteAverage;
	public Text textGoalReached;
	
	/// <summary>
	/// Track Time
	/// </summary>
	private float gameTimer = 0.0f;
	private int seconds;
	private int minutes;
	private int hours;

	/// <summary>
	/// Hit And Miss Count
	/// </summary>
	private int hitCount = 0;
	private int missCount = 0;

	/// <summary>
	/// Calculate The Arverage Hit Rate  
	/// </summary>
	private List<int> minuteAverages = new List<int>();
	private int currentMinuteCount = 0;
	private float hitAveragePerMinute = 0;
	private int goalReachedCount = 0;
	private float calculationDelay = 1.0f;

	private void Update()
	{
		gameTimer += Time.deltaTime;
		UpdateTimer();

		if (gameTimer > calculationDelay)
		{
			if (seconds == 0)
			{
				CalculatePerMinuteAverage();

				if (hours < 5)
				{
		
					RecoredPerMinuteData();
				}
				currentMinuteCount = 0;
			}

			calculationDelay = gameTimer + 1;
		}

		UpdateDisplay();
	}

	public void IncreaseHit()
	{
		hitCount++;
		currentMinuteCount++;
	}

	public void IncreaseGoalReached()
	{
		goalReachedCount++;
	}

	public void IncreaseMiss()
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
		int total = 0;

		foreach (int value in minuteAverages)
		{
			total += value;
		}

		hitAveragePerMinute = (float) total / minuteAverages.Count;
	}

	public void UpdateTimer()
	{
		seconds = (int)(Time.realtimeSinceStartup % 60);
		minutes = (int)(Time.realtimeSinceStartup / 60) % 60;
		hours = (int)(Time.realtimeSinceStartup / 3600) % 24;
	}

	public void UpdateDisplay()
	{
		textTimer.text = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
		textHitCount.text = string.Format("{0:00000}", hitCount);
		textMissCount.text = string.Format("{0:0000}", missCount);
		textCurrentMinuteCount.text = string.Format("{0:0000}", currentMinuteCount);
		textPerMinuteAverage.text = string.Format("{0:0000.00}", hitAveragePerMinute);
		textGoalReached.text = string.Format("{0:0000}", goalReachedCount);
	}

	private void RecoredPerMinuteData()
	{
		if (recoredData)
		{
			string path = "Assets/Resources/perMinuteData.csv";
			//Write some text to the test.txt file
			StreamWriter writer = new StreamWriter(path, true);
			writer.WriteLine(hitCount + "," + 
				missCount + "," + 
				currentMinuteCount + "," + 
				hitAveragePerMinute + "," + 
				goalReachedCount + "," + 
				Profiler.GetAllocatedMemoryForGraphicsDriver() + "," +
				Profiler.GetTotalAllocatedMemoryLong() + "," +
				Profiler.GetTotalReservedMemoryLong());
			writer.Close();
		}
	}
}
