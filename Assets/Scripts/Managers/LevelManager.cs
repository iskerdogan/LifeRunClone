using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
	private GameObject[] levels;

    private GameObject currentLevel;


    private void Start() 
    {
        currentLevel = Instantiate(levels[SaveManager.Instance.CurrentLevel], new Vector3(0,0,-4), Quaternion.identity);
        RoadController.Instance.FinishPlatformPosition(currentLevel.transform.GetChild(0).transform.localScale.z);
        currentLevel.SetActive(true);
    }

    public void InitNextLevel()
	{
		Destroy(currentLevel);
		currentLevel = Instantiate(levels[SaveManager.Instance.CurrentLevel], new Vector3(0,0,-4), Quaternion.identity);
		currentLevel.SetActive(true);
        RoadController.Instance.FinishPlatformPosition(currentLevel.transform.GetChild(0).transform.localScale.z);
		LeanTween.cancelAll();

		GameManager.Instance.ChangeGameState(GameState.Start);
	}

    public void InitCurrentLevel()
    {
        LeanTween.cancelAll();
        Destroy(currentLevel);
        currentLevel = Instantiate(levels[SaveManager.Instance.CurrentLevel], new Vector3(0,0,-4), Quaternion.identity);
        RoadController.Instance.FinishPlatformPosition(currentLevel.transform.GetChild(0).transform.localScale.z);

        GameManager.Instance.ChangeGameState(GameState.Start);
    } 



}
