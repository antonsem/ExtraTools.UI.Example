using Cysharp.Threading.Tasks;
using ExtraTools.UI.Base;
using ExtraTools.UI.Screen;
using UnityEngine;
#if INPUT_SYSTEM_INSTALLED
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
#endif

namespace Project.Managers
{
	public class SampleSceneUIManager : UIManagerBase
	{
		[SerializeField] private ScreenBase _defaultScreen;

#if INPUT_SYSTEM_INSTALLED
		[SerializeField] private InputSystemUIInputModule _inputModule;
#endif

		#region Unity Methods

		private void Start()
		{
			GetDialog<Project.Dialogs.Generic.GenericDialog>().Show("Startup test").Forget();
			_defaultScreen.Show().Forget();
		}

#if INPUT_SYSTEM_INSTALLED
		private void OnEnable()
		{
			_inputModule.cancel.action.performed += OnCancelPerformed;
		}

		private void OnDisable()
		{
			if (_inputModule)
			{
				_inputModule.cancel.action.performed -= OnCancelPerformed;
			}
		}
#endif

		#endregion

#if INPUT_SYSTEM_INSTALLED
		private void OnCancelPerformed(InputAction.CallbackContext context)
		{
			if (!Cancel())
			{
				Debug.Log("Nothing used Cancel", this);
			}
		}
#endif
	}
}
