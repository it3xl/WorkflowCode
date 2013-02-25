using System;
using System.Diagnostics;
using WorkflowCodeProject.Activities.Base;
using WorkflowCodeProject.Activities.Triggered;

/* TODO
 * 
 *		Write samples.
 * Moving a workflow definitions to properties.
 * Changing one workflow from another.
 * Using of a dummy properties.
 * A deferred workflow activity's pushing with the PushWorkflowActivity enum.
 * Example of each workflow activity.
 * Example of two async activity in row with waiting the first form the second.
 * 
 * The infinit activity using.
 * Create a infinit recursion with multiple activities implemented with propeties.
 * The infinit recursion workflow with selection.
 * 
 * Multi Threading example.

*/

namespace WorkflowCodeProject
{
	/// <summary>
	/// The Workflow holder.
	/// Push forward workflow by invoke the <see cref="RunNextActivity"/> method.
	/// <seealso cref="BaseActivity"/>
	/// <seealso cref="ITriggeredActivity"/>
	/// </summary>
	public class WorkflowCode
	{
		/// <summary>
		/// A workflow is started.
		/// </summary>
		private Boolean _started;

		/// <summary>
		/// The initial activity that starts first.
		/// </summary>
		public BaseActivity GlobalRootActivity { get; set; }

		/// <summary>
		/// Intermediate state for the <see cref="RunNextActivity"/> recursion. The next activity for execute.
		/// </summary>
		private BaseActivity GlobalNextActivityForRecursion { get; set; }

		/// <summary>
		/// For debugging purpose only.
		/// Set it to the true value in the debugger for instruct to stop (break)
		///  before any even empty <see cref="BaseActivity"/>.<see cref="BaseActivity.Action"/> execution.
		/// </summary>
		public static bool DebuggerBreak { get; set; }

		/// <summary>
		/// Locker for multithreaded scenario. For current <see cref="WorkflowCode"/> instance.
		/// </summary>
		private readonly Object _multyThreadProtectionLocker = new Object();

		/// <summary>
		/// It'll run a workflow's first or next activity.
		/// Use this method for start your workflow.
		/// </summary>
		public void RunNextActivity()
		{
			RunNextActivityRecursion();
		}

		/// <summary>
		/// It'll run a workflow's next activity.
		/// </summary>
		private void RunNextActivityRecursion()
		{
			BaseActivity currentExecutionActivity;
			BaseActivity nextExecutionActivity;

			lock (_multyThreadProtectionLocker)
			{
				PrepareWorkflowOnStart();

				if (GlobalNextActivityForRecursion == null)
				{
					// The workflow is over.
					return;
				}

				currentExecutionActivity = GlobalNextActivityForRecursion;

				// it3xl.ru: It's important to store locally activity of the next recursion before call the currentExecutionActivity.ExecuteActivityAction() method,
				//  because current (currentExecutionActivity) activity may start the next activity in its Action.
				// It's is important in scenario when we need dynamicly to change a triggered activity behavior (ITriggeredActivity)
				//  to the immediate activity behavior (IImmediateActivity)
				//  by calling the RunNextActivity() method in the current activity Action on some condition.
				nextExecutionActivity = currentExecutionActivity.GetNextActivity();

				// Set the activity for the next recursion.
				GlobalNextActivityForRecursion = nextExecutionActivity;
			}

			currentExecutionActivity.ExecuteActivityAction();
			currentExecutionActivity.Nullilng();

			if (nextExecutionActivity is ITriggeredActivity)
			{
				return;
			}

			RunNextActivityRecursion();
		}

		private void PrepareWorkflowOnStart()
		{
			if (_started)
			{
				// The workflow is started.
				// No more shit-code! Don't change the workflow dynamically by setting the GlobalRootActivity property! Create a new workflow!
				GlobalRootActivity = null;

				return;
			}

			if (GlobalRootActivity == null)
			{
				// The workflow is yet empty.
				return;
			}

			_started = true;

			GlobalNextActivityForRecursion = GlobalRootActivity;
			GlobalRootActivity = null;
		}

	}
}
