using UnityEngine;

public class LightButton : MonoBehaviour
{

	[System.NonSerialized]
	public int row;
	[System.NonSerialized]
	public int col;

    TyouchiLightsOutMain main;

	void Start()
	{
		AudioManager.GetInstance().PlayBGM(9);
		main = GameObject.FindGameObjectWithTag("GameController").GetComponent<TyouchiLightsOutMain>();
	}

	public void OnClick()
	{
		main.SwitchLights(row, col, false);
		AudioManager.GetInstance().PlaySound(0);
	}

}
