using System.Threading;
using Cysharp.Threading.Tasks;
using ExtraTools.UI.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Screens.Settings
{
	public class SettingsScreenUI : ScreenUIBase
	{
		[SerializeField] private Button _backButton;

		private SettingsScreen _settingsScreen;

		#region Unity Methods

		private void OnEnable()
		{
			_backButton.onClick.AddListener(OnBack);
		}

		private void OnDisable()
		{
			_backButton.onClick.RemoveListener(OnBack);
		}

		#endregion

		#region Base

		protected override void Initialize(ScreenBase screenBase)
		{
			Debug.Log($"Initializing Screen UI of type {GetType().Name}", this);
			_settingsScreen = screenBase as SettingsScreen;

			base.Initialize(screenBase);
		}

		protected override UniTask ShowAsync(CancellationToken cancellationToken = default)
		{
			Debug.Log($"Showing Screen UI of type {GetType().Name}", this);

			return base.ShowAsync(cancellationToken);
		}

		protected override UniTask HideAsync(CancellationToken cancellationToken = default)
		{
			Debug.Log($"Hiding Screen UI of type {GetType().Name}", this);

			return base.HideAsync(cancellationToken);
		}

		#endregion

		private void OnBack()
		{
			_settingsScreen.OnBack();
		}
	}
}
