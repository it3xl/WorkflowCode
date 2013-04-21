using System;
using WorkflowCodeProject.Activities.Triggered;

namespace WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// The base Infinit activity.<para/>
	/// It's similar to the <see cref="ITriggeredActivity"/> i.e. will be executed after call the <see cref="WorkflowCode.RunNextActivity()"/> from the external code.<para/>
	/// But also it may be executed once immediately by means of the property <see cref="ExecuteOnceImmediately"/> set to true.
	/// <seealso cref="ITriggeredActivity"/>
	/// </summary>
	public abstract class BaseInfiniteActivity : BaseActivity
	{
		public override BaseActivity GetNextActivity()
		{
			return this;
		}

		/// <summary>
		/// It's important ability for the infinite activity to be executed once immediately.
		/// </summary>
		public Boolean ExecuteOnceImmediately { get; set; }

		/// <summary>
		/// See comments and how to use at the <see cref="BaseActivity"/>.<see cref="BaseActivity.Nullilng"/>.
		/// </summary>
		public override sealed void Nullilng()
		{
			// it3xl.ru: We need no the nulling here because this activity is infinite.
		}
	}
}