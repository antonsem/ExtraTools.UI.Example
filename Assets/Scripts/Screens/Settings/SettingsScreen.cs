using System.Threading;
using Cysharp.Threading.Tasks;
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

		protected override UniTask HidePanelsAsync(CancellationToken cancellationToken = default)
		{
			Debug.Log($"Hiding all panels in screen of type {GetType().Name}", this);

			return base.HidePanelsAsync(cancellationToken);
		}

		protected override async UniTask ShowPanelAsync<T>(bool additive = false, CancellationToken cancellationToken = default)
		{
			Debug.Log($"Showing panel of type {typeof(T).Name} in screen of type {GetType().Name}", this);

			await base.ShowPanelAsync<T>(additive, cancellationToken);
		}

		#endregion


		internal async UniTask OnVideoSettings()
		{
			await ShowPanelAsync<VideoSettingsPanel>();
		}

		internal async UniTask OnAudioSettings()
		{
			await ShowPanelAsync<AudioSettingsPanel>();
		}

		internal void OnBack()
		{
			MainMenuScreen mainMenuScreen = UIManager.GetScreen<MainMenuScreen>();
			mainMenuScreen.Show().Forget();
		}
	}
}