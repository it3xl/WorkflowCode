using System;

namespace WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// Activity that allows you to choose the next activity from the <see cref="True"/>
	///  and <see cref="False"/> on the condition <see cref="If()"/>.
	/// <seealso cref="BaseFirstOrDefaultActivity"/>
	/// </summary>
	public abstract class BaseIfElseActivity : BaseActivity
	{
		/// <summary>
		/// Condition, which selects the next activity.
		/// </summary>
		public Func<bool> If { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<bool> DummyIf { get; set; }

		/// <summary>
		/// Activity, which will be executed if the <see cref="If"/> method return the true.
		/// </summary>
		public Func<BaseActivity> True { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<BaseActivity> DummyTrue { get; set; }


		/// <summary>
		/// Activity, which will be executed if the <see cref="If"/> method return the false.
		/// </summary>
		public Func<BaseActivity> False { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<BaseActivity> DummyFalse { get; set; }

		public override BaseActivity GetNextActivity()
		{
			if (If == null)
			{
				return null;
			}

			BaseActivity resultActivity = null;

			var ifResult = If();
			if (ifResult)
			{
				if(True != null)
				{
					resultActivity = True();
				}
			}
			else
			{
				if(False != null)
				{
					resultActivity = False();
				}
			}

			return resultActivity;
		}

		/// <summary>
		/// See comments and how to use at the <see cref="BaseActivity"/>.<see cref="BaseActivity.Nullilng"/>.
		/// </summary>
		public override void Nullilng()
		{
			Action = null;
			If = null;
			True = null;
			False = null;
		}
	}
}