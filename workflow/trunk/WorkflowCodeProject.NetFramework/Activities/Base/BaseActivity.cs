using System;
using System.Diagnostics;
using WorkflowCodeProject.Activities.Immediate;

namespace WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// The class encapsulates common functionality for all activities.
	/// </summary>
	public abstract class BaseActivity
	{
		/// <summary>
		/// Any text describes the activity.
		/// </summary>
		public String Description { get; set; }

		/// <summary>
		/// The action that will be executed by the activity.
		/// </summary>
		public Action Action { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Action DummyAction { get; set; }

		/// <summary>
		/// Запустить действие активности.
		/// </summary>
		public void ExecuteActivityAction()
		{
			if (WorkflowCode.DebuggerBreak)
			{
				Debugger.Break();
			}

			if (Action == null)
			{
				return;
			}
			Action();
		}

		/// <summary>
		/// Will return the next activity.
		/// </summary>
		/// <returns></returns>
		public abstract BaseActivity GetNextActivity();

		/// <summary>
		/// Used for:<para/>
		/// It will help get rid of the appearance of complex bugs;<para/>
		/// Speeds ​​up the release of resources;<para/>
		/// Allow to keep (to guarantee) the code simple as possible. It don't allows to use any dirty workarounds.<para/>
		/// <para/>
		/// Make here nulling of any activity states.<para/>
		/// For instance the <see cref="Action"/> of activity, all next activity gettes like the <see cref="BaseSequentialActivity.NextActivityFunc"/> etc.<para/>
		/// It depends on the implementation. See examples of use in derived classes.
		/// </summary>
		public abstract void Nullilng();
	}

}