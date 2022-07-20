using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jumpy;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Profiling.Experimental;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestScripts
{
	// [UnitySetUp] -  method with pre-sets for tests below
	// IEnumerator is used for executing pre-sets
	// SceneManager - parent class for scenes loading
	// For each test we load a "Game" scene first
	//
	//
	// 'yield return null'  - to skip 2 frames and wait to scene to get loaded

	[UnitySetUp]
	public IEnumerator Setup()
	{
		SceneManager.LoadScene("Game");
		yield return null;
		yield return null;
	}

	// [TearDown] - post-condition method, for actions that happen after tests are executed.
	// we leave it empty as we don't need such method to do anything in this case

	[TearDown]
	public void Teardown()
	{
	}
	/*
[UnityTest] - is the actual test where we make sure that game is launched after Start button is hit
         
         1) speed the game time x20
         2) find the pop-up title
         3) make sure the title is not empty with Assert function
         4) in StartButton variabe we save PlayButton state and then make sure it exists on the screen with Assert
         5) click startButton
         6) create While loop where we gonna skip 5 frames per unit time to speed the game up  
	*/
	[UnityTest]
	public IEnumerator CheckGameStartOnStartButton()
	{
		Time.timeScale = 20.0f;
		var titleScreen = Object.FindObjectOfType<TitleScreenPopup>();
		{
			Assert.IsNotNull(titleScreen);
		}

		var startButton = GameObject.Find("PlayButton");
		{
			Assert.IsNotNull(startButton);
		}

		titleScreen.PerformClickActionsPopup(startButton);
		var time = 0f;
		while (time < 5f)      // ????                      			   
		{
			time += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}

		/*
		7) when we exit the loop, we set a normal game time again (=1f)
	    10) find InGameInterface object - our game interface
	    11) make sure with (Assert) that it's not null and active
	    
	    Результат можно записать в лог
		*/
		Time.timeScale = 1f;
		var inGameInterface = Object.FindObjectOfType<InGameInterface>(true);
		{
			Assert.IsNotNull(inGameInterface);
			Assert.IsTrue(inGameInterface.gameObject.activeSelf);
		}
		Debug.Log(inGameInterface + (" loaded sucsess")); // save test result in the log file
	}
}
