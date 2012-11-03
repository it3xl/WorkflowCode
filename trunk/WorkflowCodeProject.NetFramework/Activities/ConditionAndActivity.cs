using System;
using WorkflowCodeProject.Activities.Base;

namespace WorkflowCodeProject.Activities
{
	/// <summary>
	/// Uses with the <see cref="BaseFirstOrDefaultActivity"/> to combine activity and its execution condition.
	/// </summary>
	public class ConditionAndActivity
	{
		public Func<bool> Condition { get; set; }
		public Func<BaseActivity> Activity { get; set; }
	}
}