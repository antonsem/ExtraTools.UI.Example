using System.Threading.Tasks;
using ExtraTools.UI.Panel;
using ExtraTools.UI.Screen;
using Project.Screens.Settings;
using UnityEngine;

namespace Project.Panels.AudioSettings
{
	public class AudioSettingsPanel : PanelBase
	{
		private SettingsScreen _settingsScreen;


		#region Base

		protected override void Initialize(ScreenBase screenBase)
		{
			Debug.Log($"Initializing panel of type {GetType().Name}", this);
			_settingsScreen = screenBase as SettingsScreen;

			base.Initialize(screenBase);
		}

		protected override Task HideAsync()
		{
			Debug.Log($"Hiding panel of type {GetType().Name}", this);

			return base.HideAsync();
		}

		protected override Task ShowAsync()
		{
			Debug.Log($"Showing panel of type {GetType().Name}, this");

			return base.ShowAsync();
		}

		#endregion


		internal void OnVideo()
		{
			_settingsScreen.OnVideoSettings();
		}

		internal void OnAudioChange(float value)
		{
			Debug.Log($"Set audio to {value}", this);
		}
	}
}