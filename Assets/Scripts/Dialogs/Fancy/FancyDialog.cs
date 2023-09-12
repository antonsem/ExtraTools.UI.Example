using ExtraTools.UI.Dialog;
using Project.Widgets;
using UnityEngine;

namespace Project.Dialogs.Fancy
{
	public class FancyDialog : DialogBase
	{
		protected override void OnClicked()
		{
			var settingsWidget = UIManager.GetWidget<GenericWidget>();
			settingsWidget.Show("CLICK ME!", 2, () => Debug.LogError("CLICK!"));

			base.OnClicked();
		}
	}
}