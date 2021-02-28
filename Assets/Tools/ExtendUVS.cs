using UnityEngine;
using Ludiq;
using UnityEditor;

namespace PurerLogic
{
    public static class ExtendUVS
    {
        // % control # shift &alt
        [MenuItem("ExtendUVS/Send | Copy &c")]
        public static void Send()
        {
            try
            {
                GraphClipboard.CopySelection();
                if (GraphClipboard.groupClipboard.containsData)
                {
                    GUIUtility.systemCopyBuffer = JsonUtility.ToJson(GraphClipboard.groupClipboard.data);
                    Debug.Log("JSON sent:\n" + GUIUtility.systemCopyBuffer);
                }
            }
            catch
            {
                Debug.Log("JSON send error! Is anything selected in the graph?");

            }
        }

        [MenuItem("ExtendUVS/Receive &v")]
        public static void Receive()
        {
            try
            {
                GraphClipboard.groupClipboard.GetType().GetProperty("data").SetValue(GraphClipboard.groupClipboard, JsonUtility.FromJson<SerializationData>(GUIUtility.systemCopyBuffer));
                Debug.Log("JSON received - ready to paste into graph\n## TODO: auto-paste at x,y");
            }

            catch
            { Debug.Log("JSON receive error! Have you copied JSON to memory?"); }
        }

        [MenuItem("ExtendUVS/Help &h")]
        public static void Help()
        {
            Debug.Log("PurerLogic.ExtendUVS\nAlt+C - Copy selection and send JSON  ---  Alt+V - Receive JSON ##TODO and paste selection");
        }
    }

}