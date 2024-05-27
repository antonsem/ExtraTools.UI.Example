using ExtraTools.UI.Screen;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Screens.MultiplePanel
{
	public class MultiplePanelScreenUI : ScreenUIBase
	{
		[SerializeField] private Button _toggleTopPanelButton;
		[SerializeField] private Button _toggleBottomPanelButton;
		[SerializeField] private Button _backButton;

		private MultiplePanelScreen _multiplePanelScreen;


		#region Unity Methods

		private void OnEnable()
		{
			_toggleTopPanelButton.onClick.AddListener(OnToggleTop);
			_toggleBottomPanelButton.onClick.AddListener(OnToggleBottom);
			_backButton.onClick.AddListener(OnBack);
		}

		private void OnDisable()
		{
			_toggleTopPanelButton.onClick.RemoveListener(OnToggleTop);
			_toggleBottomPanelButton.onClick.RemoveListener(OnToggleBottom);
			_backButton.onClick.RemoveListener(OnBack);
		}

		#endregion

		#region Base

		protected override void Initialize(ScreenBase screenBase)
		{
			base.Initialize(screenBase);
			_multiplePanelScreen = (MultiplePanelScreen)screenBase;
		}

		#endregion


		private void OnToggleTop()
		{
			_multiplePanelScreen.ToggleTopPanel();
		}

		private void OnToggleBottom()
		{
			_multiplePanelScreen.ToggleBottomPanel();
		}

		private void OnBack()
		{
			_multiplePanelScreen.OnBack();
		}
	}
}