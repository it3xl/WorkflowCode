using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkflowCodeProject.Code
{
    public class FuncHelper<TResult>
    {
        public static readonly Func<TResult> DoNothingReturnDefault = () => default(TResult);
    }

    public class FuncHelper<TParam, TResult>
    {
        public static readonly Func<TParam, TResult> DoNothingReturnDefault = param => default(TResult);
    }
}
