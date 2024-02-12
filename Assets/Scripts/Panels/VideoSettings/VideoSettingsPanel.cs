using System.Threading.Tasks;
using ExtraTools.UI.Panel;
using ExtraTools.UI.Screen;
using Project.Screens.Settings;
using UnityEngine;

namespace Project.Panels.VideoSettings
{
	public class VideoSettingsPanel : PanelBase
	{
		private SettingsScreen _settingsScreen;
		private VideoSettingsPanelUI _videoSettingsPanelUI;


		#region Unity Methods

		private void Start()
		{
			OnChangeResolution();
		}

		#endregion

		#region Base

		protected override void Initialize(ScreenBase screenBase)
		{
			Debug.Log($"Initializing panel of type {GetType().Name}", this);
			_settingsScreen = screenBase as SettingsScreen;

			base.Initialize(screenBase);

			_videoSettingsPanelUI = _panelUI as VideoSettingsPanelUI;
		}

		protected override Task HideAsync()
		{
			Debug.Log($"Hiding panel of type {GetType().Name}", this);

			return base.HideAsync();
		}

		protected override Task ShowAsync()
		{
			Debug.Log($"Showing panel of type {GetType().Name}", this);

			return base.ShowAsync();
		}

		#endregion


		internal void OnAudio()
		{
			_settingsScreen.OnAudioSettings();
		}

		internal void OnChangeResolution()
		{
			_videoSettingsPanelUI.SetResolution(Random.Range(640, 1920), Random.Range(480, 1080));
		}
	}
}