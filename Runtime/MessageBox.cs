using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CampStudio.MessageBox
{
    public static partial class MessageBox
    {
        public static void Show(string tittle, string text)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorUtility.DisplayDialog(tittle, text, "OK");
            #else
                NativeDialog.DialogManager.SetLabel("OK", "Ok", "Ok");
                NativeDialog.DialogManager.ShowSubmit(text, text, _ => {});
            #endif
        }
    }
}
