namespace WorkflowCodeProject.Activities.Base
{
	/// <summary>
	/// The Infinit activity.
	/// </summary>
	public class BaseInfinitActivity : BaseActivity
	{
		public override BaseActivity GetNextActivity()
		{
			return this;
		}

		/// <summary>
		/// See comments and how to use at the <see cref="BaseActivity"/>.<see cref="BaseActivity.Nullilng"/>.
		/// </summary>
		public override void Nullilng()
		{
			// it3xl.ru: We need no nulling here because this activity is infinite.
		}
	}
}