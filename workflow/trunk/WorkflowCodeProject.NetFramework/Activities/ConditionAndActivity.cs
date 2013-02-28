using System;
using WorkflowCodeProject.Activities.Base;

namespace WorkflowCodeProject.Activities
{
	/// <summary>
	/// Uses with the <see cref="BaseFirstOrDefaultActivity"/> to combine activity and its execution condition.
	/// </summary>
	public class ConditionAndActivity
	{
		/// <summary>
		/// Condition, that approve the <see cref="Activity"/> of this instance of the <see cref="ConditionAndActivity"/>.
		/// </summary>
		public Func<bool> Condition { get; set; }

		/// <summary>
		/// The Action that will be executed if Condition is valid.
		/// </summary>
		public Func<BaseActivity> Activity { get; set; }

		/// <summary>
		/// Any text describes the activity.
		/// </summary>
		public String Description { get; set; }
	}
}