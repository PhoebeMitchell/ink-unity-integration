using System;
using UnityEngine;
using System.Reflection;

namespace Ink.Runtime
{
    public class NarrativeAction : Runtime.Object
    {
        string _actionLine = "";

        public NarrativeAction (string actionLine)
        {
            _actionLine = actionLine;
            var actionNameAndArguments = actionLine.Substring(1).Split(':');
            var actionName = actionNameAndArguments[0];
            string[] arguments = actionNameAndArguments.Length > 1 ? actionNameAndArguments[1].Split(",") : Array.Empty<string>();

            TestScript test = UnityEngine.Object.FindObjectOfType<TestScript>();
            var methodInfo = typeof(TestScript).GetMethod(actionName, BindingFlags.Instance | BindingFlags.NonPublic);
            Debug.Log(methodInfo);
        }

        public override Object Copy()
        {
            return new NarrativeAction (_actionLine);
        }

        public override string ToString ()
        {
            return _actionLine.ToString();
        }
    }
}

