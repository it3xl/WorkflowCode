using System;

namespace WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// The most simple and straightforward activity.
	/// Performs the action and give the work to the next activity.
	/// </summary>
	public abstract class BaseSequentialActivity : BaseActivity
	{
		/// <summary>
		/// The next activity.
		/// </summary>
		public Func<BaseActivity> NextActivityFunc { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<BaseActivity> NextActivityFuncDummy { get; set; }
		
		public override BaseActivity GetNextActivity()
		{
			var nextActivityFunc = NextActivityFunc;
		    if (nextActivityFunc == null)
		    {
		        return null;
		    }

		    return nextActivityFunc();
		}

		/// <summary>
		/// See comments and how to use at the <see cref="BaseActivity"/>.<see cref="BaseActivity.Nullilng"/>.
		/// </summary>
		public override void Nullilng()
		{
			Action = null;
			NextActivityFunc = null;
		}
	}
}