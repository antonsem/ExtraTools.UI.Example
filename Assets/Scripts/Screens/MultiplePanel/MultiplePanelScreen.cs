using ExtraTools.UI.Panel;
using ExtraTools.UI.Screen;
using Project.Screens.MainMenu;
using UnityEngine;

namespace Project.Screens.MultiplePanel
{
	public class MultiplePanelScreen : ScreenBase
	{
		[SerializeField] private PanelBase[] _topPanels;
		[SerializeField] private PanelBase[] _bottomPanels;

		private int _activeTopPanel;
		private int _activeBottomPanel;

		internal async void ToggleTopPanel()
		{
			await HidePanelAsync(_topPanels[_activeTopPanel]);
			_activeTopPanel = (_activeTopPanel + 1) % _topPanels.Length;
			await ShowPanelAsync(_topPanels[_activeTopPanel], true);
		}

		internal async void ToggleBottomPanel()
		{
			await HidePanelAsync(_bottomPanels[_activeBottomPanel]);
			_activeBottomPanel = (_activeBottomPanel + 1) % _bottomPanels.Length;
			await ShowPanelAsync(_bottomPanels[_activeBottomPanel], true);
		}

		internal void OnBack()
		{
			UIManager.GetScreen<MainMenuScreen>().Show();
		}
	}
}