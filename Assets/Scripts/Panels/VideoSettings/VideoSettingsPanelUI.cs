using System.Threading.Tasks;
using ExtraTools.UI.Panel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Panels.VideoSettings
{
	public class VideoSettingsPanelUI : PanelUIBase
	{
		[SerializeField] private Button _audioButton;
		[SerializeField] private Button _resolutionButton;
		[SerializeField] private TMP_Text _resolutionText;

		private VideoSettingsPanel _videoSettingsPanel;


		#region Unity Methods

		private void OnEnable()
		{
			_audioButton.onClick.AddListener(OnAudio);
			_resolutionButton.onClick.AddListener(OnResolution);
		}

		private void OnDisable()
		{
			_audioButton.onClick.RemoveListener(OnAudio);
			_resolutionButton.onClick.RemoveListener(OnResolution);
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
			_resolutionText.text = $"{width}x{height}";
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