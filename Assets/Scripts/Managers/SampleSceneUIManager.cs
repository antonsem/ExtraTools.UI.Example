using ExtraTools.UI.Base;
using ExtraTools.UI.Screen;
using UnityEngine;

namespace Project.Managers
{
	public class SampleSceneUIManager : UIManagerBase
	{
		[SerializeField] private ScreenBase defaultScreen;

		private void Start()
		{
			defaultScreen.Show();
		}
	}
}