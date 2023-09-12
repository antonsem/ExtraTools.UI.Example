using System.Threading.Tasks;
using ExtraTools.UI.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Screens.MainMenu
{
	public class MainMenuScreenUI : ScreenUIBase
	{
		[SerializeField] private Button startGameButton;
		[SerializeField] private Button settingsButton;
		[SerializeField] private Button fancyDialogButton;
		[SerializeField] private Button quitButton;

		private MainMenuScreen _mainMenuScreen;


		#region Unity Methods

		private void OnEnable()
		{
			startGameButton.onClick.AddListener(OnStartGame);
			settingsButton.onClick.AddListener(OnSettings);
			fancyDialogButton.onClick.AddListener(OnFancyDialog);
			quitButton.onClick.AddListener(OnQuit);
		}

		private void OnDisable()
		{
			startGameButton.onClick.RemoveAllListeners();
			settingsButton.onClick.RemoveAllListeners();
			fancyDialogButton.onClick.RemoveAllListeners();
			quitButton.onClick.RemoveAllListeners();
		}

		#endregion

		#region Base

		protected override void Initialize(ScreenBase screenBase)
		{
			Debug.Log($"Initializing Screen UI of type {GetType().Name}", this);
			_mainMenuScreen = screenBase as MainMenuScreen;

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


		private void OnStartGame()
		{
			_mainMenuScreen.OnStartGame();
		}

		private void OnSettings()
		{
			_mainMenuScreen.OnSettings();
		}

		private void OnFancyDialog()
		{
			_mainMenuScreen.OnFancyDialog();
		}

		private void OnQuit()
		{
			_mainMenuScreen.OnQuit();
		}
	}
}