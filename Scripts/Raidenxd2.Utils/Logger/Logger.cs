using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace LoggerSystem
{
    public class Logger : MonoBehaviour
    {

        public static void Log(string text, LogTypes logTypes)
        {
            StackFrame frame = new StackFrame(1, true);
            var method = frame.GetMethod().Name;
            var fileName = frame.GetFileName();
            var lineNumber = frame.GetFileLineNumber();
            var logString = " [" + fileName + ":" + lineNumber + "] (" + method + ") ";

            switch (logTypes)
            {
                case LogTypes.Normal:
                    Debug.Log(GetLogTypeName(logTypes) + logString + text);
                    break;
                case LogTypes.Error:
                    Debug.LogError($"<color=#ff4d4d>" + GetLogTypeName(logTypes) + logString + text + "</color>");
                    break;
                case LogTypes.Warning:
                    Debug.LogWarning($"<color=#ffe347>" + GetLogTypeName(logTypes) + logString + text + "</color>");
                    break;
                case LogTypes.Exception:
                    Debug.LogError($"<color=#ff4d4d>" + GetLogTypeName(logTypes) + logString + text + "</color>");
                    break;
                case LogTypes.Assertion:
                    Debug.LogAssertion($"<color=#ff4d4d>" + GetLogTypeName(logTypes) + logString + text + "</color>");
                    break;
                default:
                    throw new System.Exception("Unknown LogType.");
            }
        }

        public static string GetLogTypeName(LogTypes logTypes)
        {
            switch (logTypes)
            {
                case LogTypes.Normal:
                    return "[LOG]";
                case LogTypes.Error:
                    return "[ERROR]";
                case LogTypes.Warning:
                    return "[WARNING]";
                case LogTypes.Exception:
                    return "[EXCEPTION]";
                case LogTypes.Assertion:
                    return "[ASSERTION]";
                default:
                    throw new System.Exception("Unknown LogType.");
            }
        }

    }

    public enum LogTypes
    {
        Normal,
        Error,
        Warning,
        Exception,
        Assertion
    }
}


