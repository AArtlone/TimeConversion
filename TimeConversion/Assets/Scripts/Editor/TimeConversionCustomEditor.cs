using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TimeConversion))]
public class TimeConversionCustomEditor : Editor
{
    private TimeConversion timeConversionObject;

    private SerializedProperty secondsProperty;
    private SerializedProperty minutesProperty;
    private SerializedProperty hoursProperty;
    
    private readonly string secondsLabel = "Seconds";
    private readonly string minutesLabel = "Minutes";
    private readonly string hoursLabel = "Hours";

    private readonly string secondsBtnLabel = "Calculate Seconds";
    private readonly string minutesBtnLabel = "Calculate Minutes";
    private readonly string hoursBtnLabel = "Calculate Hours";

    private void OnEnable()
    {
        timeConversionObject = (target as TimeConversion);

        secondsProperty = serializedObject.FindProperty("seconds");
        minutesProperty = serializedObject.FindProperty("minutes");
        hoursProperty = serializedObject.FindProperty("hours");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DisplaySecondsInterface();
        DisplayMinutesInterface();
        DisplayHoursInterface();
        serializedObject.ApplyModifiedProperties();
    }

    private void DisplaySecondsInterface()
    {
        GUILayout.BeginHorizontal();
        
        secondsProperty.intValue = EditorGUILayout.IntField(secondsLabel, secondsProperty.intValue);
        if (GUILayout.Button(secondsBtnLabel))
            timeConversionObject.CalculateSeconds();

        GUILayout.EndHorizontal();
    }

    private void DisplayMinutesInterface()
    {
        GUILayout.BeginHorizontal();

        minutesProperty.intValue = EditorGUILayout.IntField(minutesLabel, minutesProperty.intValue);
        if (GUILayout.Button(minutesBtnLabel))
            timeConversionObject.CalculateMinutes();

        GUILayout.EndHorizontal();
    }

    private void DisplayHoursInterface()
    {
        GUILayout.BeginHorizontal();

        hoursProperty.intValue = EditorGUILayout.IntField(hoursLabel, hoursProperty.intValue);
        if (GUILayout.Button(hoursBtnLabel))
            timeConversionObject.CalculateHours();
        
        GUILayout.EndHorizontal();
    }
}
