using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GFunc
{
    #region Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif// DEBUG_MODE
        //Debug.Log(message);
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Log(object message, UnityEngine.Object context)
    {
#if DEBUG_MODE
        Debug.Log(message, context);
#endif //DEBUG_MODE
        //Debug.Log(message, context);
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif// DEBUG_MODE
        //Debug.Log(message);
    }
    #endregion //#region Print log func

    #region Assert for debug
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif

        // Debug.Assert(condition);
    }
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition, object message)
    {
#if DEBUG_MODE
        Debug.Assert(condition, message);
#endif

        //Debug.Assert(condition);
    }
    #endregion // Assert for debug

    #region Vaild Func
    public static bool IsValid<T>(this T component_)
    {
        bool isValid = component_.Equals(null) == false;
        return isValid;
        //if (component_ == null || component_ == default) { /*Do Nothing*/}
        //else
        //{
        //    isValid = true;
        //}
    }
    #endregion //vaild Func
}

