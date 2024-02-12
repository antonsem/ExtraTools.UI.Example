using System.Threading.Tasks;
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
			_backButton.onClick.RemoveAllListeners();
		}

		#endregion

		#region Base

		protected override void Initialize(ScreenBase screenBase)
		{
			Debug.Log($"Initializing Screen UI of type {GetType().Name}", this);
			_settingsScreen = screenBase as SettingsScreen;

			base.Initialize(screenBase);
		}

		protected override Task Show()
		{
			Debug.Log($"Showing Screen UI of type {GetType().Name}", this);

			return base.Show();
		}

		protected override Task Hide()
		{
			Debug.Log($"Hiding Screen UI of type {GetType().Name}", this);

			return base.Hide();
		}

		#endregion


		private void OnBack()
		{
			_settingsScreen.OnBack();
		}
	}
}