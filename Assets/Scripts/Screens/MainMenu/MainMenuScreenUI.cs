using System.Threading.Tasks;
using ExtraTools.UI.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Screens.MainMenu
{
	public class MainMenuScreenUI : ScreenUIBase
	{
		[SerializeField] private Button _startGameButton;
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _fancyDialogButton;
		[SerializeField] private Button _multiplePanelsExampleButton;
		[SerializeField] private Button _quitButton;

		private MainMenuScreen _mainMenuScreen;

		#region Unity Methods

		private void OnEnable()
		{
			_startGameButton.onClick.AddListener(OnStartGame);
			_settingsButton.onClick.AddListener(OnSettings);
			_fancyDialogButton.onClick.AddListener(OnFancyDialog);
			_multiplePanelsExampleButton.onClick.AddListener(OnMultiplePanels);
			_quitButton.onClick.AddListener(OnQuit);
		}

		private void OnDisable()
		{
			_startGameButton.onClick.RemoveListener(OnStartGame);
			_settingsButton.onClick.RemoveListener(OnSettings);
			_fancyDialogButton.onClick.RemoveListener(OnFancyDialog);
			_multiplePanelsExampleButton.onClick.RemoveListener(OnMultiplePanels);
			_quitButton.onClick.RemoveListener(OnQuit);
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

		private void OnMultiplePanels()
		{
			_mainMenuScreen.OnMultiplePanels();
		}

		private void OnQuit()
		{
			_mainMenuScreen.OnQuit();
		}
	}
}