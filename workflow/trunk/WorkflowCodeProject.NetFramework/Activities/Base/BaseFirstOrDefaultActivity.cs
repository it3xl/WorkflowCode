using System;
using System.Collections.Generic;
using It3xl.WorkflowCodeProject.Code;

namespace It3xl.WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// Allows to select next activity.<para/>
	/// It will be the first satisfying activity from the <see cref="ActivityWithConditionQueue"/> or a default activity from the <see cref="DefaultActivity"/>.
	/// <seealso cref="BaseIfElseActivity"/>
	/// </summary>
	public abstract class BaseFirstOrDefaultActivity : BaseActivity
	{
		/// <summary>
		/// The queue of activities with their execution conditions. Or null, or the empty Queue.
		/// </summary>
		public Queue<ConditionAndActivity> ActivityWithConditionQueue { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Queue<ConditionAndActivity> DummyActivityWithConditionQueue { get; set; }

		/// <summary>
		/// The default activity that will be executed if the <see cref="ActivityWithConditionQueue"/> has no satisfactory activity.<para/>
		/// Or null.
		/// </summary>
		public Func<BaseActivity> DefaultActivity { get; set; }

		/// <summary>
		/// Properties with the Dummy suffix used to simplify editing and replacement of appropriate
		///  properties without this suffix. You may ignore it.
		/// </summary>
		public Func<BaseActivity> DummyDefaultActivity { get; set; }

		public override BaseActivity GetNextActivity()
		{
			var activityWithConditionQueue = ActivityWithConditionQueue;
			var defaultActivity = DefaultActivity ?? FuncHelper<BaseActivity>.DoNothingReturnDefault;

			if (activityWithConditionQueue == null)
			{
				// Have no activities queue.

				return defaultActivity();
			}

			BaseActivity resultActivity = null;
			// Using of the hasVariant flag because the resultActivity allowed to be null.
			var hasVariant = false;

			foreach (var conditionAndActivity in activityWithConditionQueue)
			{
				if (conditionAndActivity == null)
				{
					continue;
				}
				if (conditionAndActivity.Condition == null)
				{
					continue;
				}

				if(conditionAndActivity.Condition())
				{
					// It is the first satisfactory conditionAndActivityPair pair.

					hasVariant = true;

					if (conditionAndActivity.Activity != null)
					{
						resultActivity = conditionAndActivity.Activity();
					}

					break;
				}
			}

			if (hasVariant == false)
			{
				// Has no a satisfactory activity.

				resultActivity = defaultActivity();
			}

			return resultActivity;
		}

		/// <summary>
		/// See comments and how to use at the <see cref="BaseActivity"/>.<see cref="BaseActivity.Nullilng"/>.
		/// </summary>
		public override void Nullilng()
		{
			Action = null;
			ActivityWithConditionQueue = null;
			DefaultActivity = null;
		}
	}
}