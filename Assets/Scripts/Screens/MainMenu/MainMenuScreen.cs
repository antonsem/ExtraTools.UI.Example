using System.Threading;
using Cysharp.Threading.Tasks;
using ExtraTools.UI.Base;
using ExtraTools.UI.Dialog;
using ExtraTools.UI.Screen;
using Project.Dialogs.Fancy;
using Project.Dialogs.Generic;
using Project.Screens.MultiplePanel;
using Project.Screens.Settings;
using UnityEngine;

namespace Project.Screens.MainMenu
{
	public class MainMenuScreen : ScreenBase
	{
		private DialogAnswer[] _newGameDialogAnswers;
		private DialogAnswer[] _quitDialogAnswers;

		#region Unity Methods

		private void Awake()
		{
			_quitDialogAnswers = new[]
			{
				new DialogAnswer("Yes!", DoQuit),
				// Default, so it is focused and used for Cancel: a stray Submit or Back press does not quit.
				new DialogAnswer("No", isDefault: true),
			};

			_newGameDialogAnswers = new[]
			{
				new DialogAnswer("New Game!", OnNewGame),
				new DialogAnswer("Continue", OnContinue),
			};
		}

		#endregion

		internal void OnStartGame()
		{
			GenericDialog dialog = UIManager.GetDialog<GenericDialog>();
			dialog.Show("Start a new game?", _newGameDialogAnswers).Forget();
		}

		internal void OnSettings()
		{
			SettingsScreen settingsScreen = UIManager.GetScreen<SettingsScreen>();
			settingsScreen.Show().Forget();
		}

		internal void OnFancyDialog()
		{
			UIManager.GetDialog<FancyDialog>().Show("Click OK to see a widget...").Forget();
		}

		internal void OnMultiplePanels()
		{
			UIManager.GetScreen<MultiplePanelScreen>().Show().Forget();
		}

		internal void OnQuit()
		{
			GenericDialog dialog = UIManager.GetDialog<GenericDialog>();
			dialog.Show("Are you sure you want to quit?", _quitDialogAnswers).Forget();
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

		protected override async UniTask ShowPanelAsync<T>(bool additive = false,
			CancellationToken cancellationToken = default)
		{
			Debug.Log($"Showing panel of type {typeof(T).Name} in screen of type {GetType().Name}", this);

			await base.ShowPanelAsync<T>(additive, cancellationToken);
		}

		#endregion
	}
}
