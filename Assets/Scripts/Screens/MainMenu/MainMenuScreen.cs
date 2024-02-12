using System.Threading.Tasks;
using ExtraTools.UI.Base;
using ExtraTools.UI.Dialog;
using ExtraTools.UI.Screen;
using Project.Dialogs.Fancy;
using Project.Dialogs.Generic;
using Project.Screens.Settings;
using UnityEngine;

namespace Project.Screens.MainMenu
{
	public class MainMenuScreen : ScreenBase
	{
		private DialogAnswer[] _quitDialogAnswers;
		private DialogAnswer[] _newGameDialogAnswers;


		#region Unity Methods

		private void Awake()
		{
			_quitDialogAnswers = new[]
			{
				new DialogAnswer("Yes!", DoQuit),
				new DialogAnswer("No")
			};

			_newGameDialogAnswers = new[]
			{
				new DialogAnswer("New Game!", OnNewGame),
				new DialogAnswer("Continue", OnContinue)
			};
		}

		#endregion

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

		protected override void ShowPanelAsync<T>()
		{
			Debug.Log($"Showing panel of type {typeof(T).Name} in screen of type {GetType().Name}", this);

			base.ShowPanelAsync<T>();
		}

		#endregion


		internal void OnStartGame()
		{
			GenericDialog dialog = UIManager.GetDialog<GenericDialog>();
			dialog.Show("Start a new game?", _newGameDialogAnswers);
		}

		internal void OnSettings()
		{
			SettingsScreen settingsScreen = UIManager.GetScreen<SettingsScreen>();
			settingsScreen.Show();
		}

		internal void OnFancyDialog()
		{
			UIManager.GetDialog<FancyDialog>().Show("Click OK to see a widget...");
		}

		internal void OnQuit()
		{
			GenericDialog dialog = UIManager.GetDialog<GenericDialog>();
			dialog.Show("Are you sure you want to quit?", _quitDialogAnswers);
		}

		private void DoQuit()
		{
			Debug.Log("Quitting...", this);
		}

		private void OnNewGame()
		{
			Debug.Log("Starting new game", this);
		}

		private void OnContinue()
		{
			Debug.Log("Continue", this);
		}
	}
}