using ExtraTools.UI.Dialog;
using Project.Widgets;
using UnityEngine;

namespace Project.Dialogs.Fancy
{
	public class FancyDialog : DialogBase
	{
		#region Base

		protected override void OnClicked()
		{
			GenericWidget settingsWidget = UIManager.GetWidget<GenericWidget>();
			settingsWidget.Show("CLICK ME!", 2, () => Debug.LogError("CLICK!"));

			base.OnClicked();
		}

		#endregion
	}
}