using System.Threading.Tasks;
using ExtraTools.UI.Panel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Panels.VideoSettings
{
	public class VideoSettingsPanelUI : PanelUIBase
	{
		[SerializeField] private Button audioButton;
		[SerializeField] private Button resolutionButton;
		[SerializeField] private TMP_Text resolutionText;

		private VideoSettingsPanel _videoSettingsPanel;


		#region Unity Methods

		private void OnEnable()
		{
			audioButton.onClick.AddListener(OnAudio);
			resolutionButton.onClick.AddListener(OnResolution);
		}

		private void OnDisable()
		{
			audioButton.onClick.RemoveAllListeners();
			resolutionButton.onClick.RemoveAllListeners();
		}

		#endregion

		#region Base

		protected override void Initialize(PanelBase panelBase)
		{
			_videoSettingsPanel = panelBase as VideoSettingsPanel;

			base.Initialize(panelBase);
		}

		protected override Task ShowAsync()
		{
			Debug.Log($"Showing Panel UI of type {GetType().Name}", this);

			return base.ShowAsync();
		}

		protected override Task HideAsync()
		{
			Debug.Log($"Hiding Panel UI of type {GetType().Name}", this);

			return base.HideAsync();
		}

		#endregion


		internal void SetResolution(int width, int height)
		{
			resolutionText.text = $"{width}x{height}";
		}

		private void OnResolution()
		{
			_videoSettingsPanel.OnChangeResolution();
		}

		private void OnAudio()
		{
			_videoSettingsPanel.OnAudio();
		}
	}
}