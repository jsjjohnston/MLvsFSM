using UnityEngine;
using UnityEngine.UI;

public class DataCollector : MonoBehaviour{
	private int killCount = 0;

	public Text textKillCount;

	private void Update()
	{
		updateDisplay();
	}

	public void increaseHit()
	{
		killCount++;
	}

	public void updateDisplay()
	{
		textKillCount.text = "" + killCount;
	}
}
