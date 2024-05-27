using System.Threading.Tasks;
using ExtraTools.UI.Panel;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Panels.AudioSettings
{
	public class AudioSettingsPanelUI : PanelUIBase
	{
		[SerializeField] private Button _videoButton;
		[SerializeField] private Slider _audioSlider;

		private AudioSettingsPanel _audioSettingsPanel;


		#region Unity Methods

		private void OnEnable()
		{
			_videoButton.onClick.AddListener(OnVideo);
			_audioSlider.onValueChanged.AddListener(OnAudioChange);
		}

		private void OnDisable()
		{
			_videoButton.onClick.RemoveListener(OnVideo);
			_audioSlider.onValueChanged.RemoveListener(OnAudioChange);
		}

		#endregion

		#region Base

		protected override void Initialize(PanelBase panelBase)
		{
			_audioSettingsPanel = panelBase as AudioSettingsPanel;

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


		private void OnVideo()
		{
			_audioSettingsPanel.OnVideo();
		}

		private void OnAudioChange(float value)
		{
			_audioSettingsPanel.OnAudioChange(value);
		}
	}
}