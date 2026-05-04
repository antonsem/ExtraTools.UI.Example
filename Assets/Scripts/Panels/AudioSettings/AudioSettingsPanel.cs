using System.Threading;
using Cysharp.Threading.Tasks;
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

		protected override UniTask HideAsync(CancellationToken cancellationToken = default)
		{
			Debug.Log($"Hiding panel of type {GetType().Name}", this);

			return base.HideAsync(cancellationToken);
		}

		protected override UniTask ShowAsync(CancellationToken cancellationToken = default)
		{
			Debug.Log($"Showing panel of type {GetType().Name}, this");

			return base.ShowAsync(cancellationToken);
		}

		#endregion


		internal void OnVideo()
		{
			_settingsScreen.OnVideoSettings().Forget();
		}

		internal void OnAudioChange(float value)
		{
			Debug.Log($"Set audio to {value}", this);
		}
	}
}