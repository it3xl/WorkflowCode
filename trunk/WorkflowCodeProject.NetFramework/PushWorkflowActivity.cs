namespace WorkflowCodeProject
{
	/// <summary>
	/// Instructs pending operations to push workflow on a next step or not.
	/// </summary>
	public enum PushWorkflowActivity
	{
		/// <summary>
		/// Not inited.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// Don't push workflow.
		/// </summary>
		No,
		
		/// <summary>
		////Push workflow.
		/// </summary>
		YesPushActivity,
	}
}