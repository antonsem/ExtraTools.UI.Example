﻿using System.Threading.Tasks;
using ExtraTools.UI.Base;
using ExtraTools.UI.Screen;
using Project.Panels.AudioSettings;
using Project.Panels.VideoSettings;
using Project.Screens.MainMenu;
using UnityEngine;

namespace Project.Screens.Settings
{
	public class SettingsScreen : ScreenBase
	{
		#region Base

		protected override void Initialize(UIManagerBase uiManager)
		{
			Debug.Log($"Initializing Screen of type {GetType().Name}", this);

			base.Initialize(uiManager);
		}

		protected override Task HidePanelsAsync()
		{
			Debug.Log($"Hiding all panels in screen of type {GetType().Name}", this);

			return base.HidePanelsAsync();
		}

		protected override async Task ShowPanelAsync<T>(bool additive = false)
		{
			Debug.Log($"Showing panel of type {typeof(T).Name} in screen of type {GetType().Name}", this);

			await base.ShowPanelAsync<T>(additive);
		}

		#endregion


		internal async void OnVideoSettings()
		{
			await ShowPanelAsync<VideoSettingsPanel>();
		}

		internal async void OnAudioSettings()
		{
			await ShowPanelAsync<AudioSettingsPanel>();
		}

		internal void OnBack()
		{
			MainMenuScreen mainMenuScreen = UIManager.GetScreen<MainMenuScreen>();
			mainMenuScreen.Show();
		}
	}
}