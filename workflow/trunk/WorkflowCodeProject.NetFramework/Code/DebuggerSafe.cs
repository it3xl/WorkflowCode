﻿using System.Diagnostics;

namespace It3xl.WorkflowCodeProject.Code
{
	/// <summary>
	/// Safe using of the <see cref="Debugger"/> functionality.
	/// </summary>
	public static class DebuggerSafe
	{

		/// <summary>
		/// Safe analog of the <see cref="Debugger.Break"/>.<para/>
		/// If you compile your app at the Debug mode and start it without a attached debugger (Visual Studio),
		///  then the <see cref="Debugger.Break"/> will crush your app.
		/// </summary>
		public static void Break()
		{
#if DEBUG
			if (Debugger.IsAttached == false)
			{
				return;
			}

			Debugger.Break();
#endif
		}
	}
}
