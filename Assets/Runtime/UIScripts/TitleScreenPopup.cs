﻿namespace Jumpy
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Controls the Title Screen UI
    /// </summary>
    public class TitleScreenPopup : GenericPopup
    {
        public Image soundButton;
        public Sprite onTexture;
        public Sprite offTexture;
        public GameObject restoreButton;
        public Text playText;
        public Text restoreText1;
        public Text restoreText2;


        // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        /// Refreshes the state of the UI buttons 
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
#if !UNITY_IOS
            restoreButton.SetActive(false);
#endif
	        UpdateButtons();
        }


        // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        /// Handles the button click actions
        /// </summary>
        /// <param name="button">the gameObject that was clicked</param>
        public override void PerformClickActionsPopup(GameObject button)
        {
            base.PerformClickActionsPopup(button);
            if (button.name == "PlayButton")
            {
                ClosePopup(false, () =>
                {
                    AssetsLoader.LoadInterface(GameInterfeces.InGameInterface);
                    LevelManager.Instance.RestartLevel();
                });
            }

            if (button.name == "SoundButton")
            {
                if (GameStatus.FXVolume == 0)
                {
                    GameStatus.FXVolume = 1;
                }
                else
                {
                    GameStatus.FXVolume = 0;
                }
                UpdateButtons();
            }
        }



        // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        /// Updates the sound settings and changes the Sound Button sprite accordingly
        /// </summary>
        private void UpdateButtons()
        {
            if (GameStatus.FXVolume == 0)
            {
                soundButton.sprite = offTexture;
            }
            else
            {
                soundButton.sprite = onTexture;
            }
            GameStatus.MusicVolume = GameStatus.FXVolume;
            SoundLoader.SetFXVoulme(GameStatus.FXVolume);
            SoundLoader.SetMusicVoulme(GameStatus.MusicVolume);
            GameStatus.SaveGameStatus();
        }
    }
}