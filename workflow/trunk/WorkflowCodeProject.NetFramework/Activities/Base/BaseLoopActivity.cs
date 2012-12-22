using System;

namespace WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// The loop activity. Works like the "while" cycle.
	/// Will be executed until the <see cref="Continue"/> returns the true..
	/// </summary>
	public abstract class BaseLoopActivity : BaseActivity
	{
		/// <summary>
		/// If returns the false, the loop will end.
		/// </summary>
		public Func<bool> Continue { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<bool> DummyContinue { get; set; }

		/// <summary>
		/// Activity, which will be executed after the completion of the loop (cycle).
		/// </summary>
		public Func<BaseActivity> NextActivity { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<BaseActivity> DummyNextActivityFunc { get; set; }

		public override BaseActivity GetNextActivity()
		{
			if (Continue == null)
			{
				return GetNextActivityAndPrepareExitFromLoop();
			}

			if (Continue())
			{
				return this;
			}
			
			return GetNextActivityAndPrepareExitFromLoop();
		}

		/// <summary>
		/// Prepares a way out of the loop.
		/// </summary>
		/// <returns></returns>
		private BaseActivity GetNextActivityAndPrepareExitFromLoop()
		{
			var nextActivity = NextActivity;

			NullilngOfLoopActivity();

			if (nextActivity != null)
			{
				return nextActivity();
			}

			return null;
		}

		/// <summary>
		/// Nulling of the loop activity states.
		/// </summary>
		private void NullilngOfLoopActivity()
		{
			Action = null;
			NextActivity = null;
			Continue = null;
		}

		/// <summary>
		/// In the Loop Activitise it's important to use the nulling in special time - see use of the <see cref="NullilngOfLoopActivity"/> method.<para/>
		/// See comments and how to use at the <see cref="BaseActivity"/>.<see cref="BaseActivity.Nullilng"/>.
		/// </summary>
		public override void Nullilng()
		{
			// Do nothing here for this type. See the NullilngOfLoopActivity method.
		}
	}
}