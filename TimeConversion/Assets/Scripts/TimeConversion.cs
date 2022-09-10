using System.Reflection;
using UnityEngine;

public class TimeConversion : MonoBehaviour
{
    [SerializeField] private int seconds = default;
    [SerializeField] private int minutes = default;
    [SerializeField] private int hours = default;

    [ExecuteInEditMode]
    public void CalculateSeconds()
    {
        ClearLog();

        int displaySeconds = seconds % 60;
        int displayMinutes = (seconds / 60) % 60;
        int displayHours = (seconds / 3600) % 24;
        int displayDays = seconds / 86400;

        Debug.Log($"{displayDays} days, {displayHours} hours, {displayMinutes} minutes, {displaySeconds} seconds.");
    }

    [ExecuteInEditMode]
    public void CalculateMinutes()
    {
        ClearLog();

        int displayMinutes = minutes % 60;
        int displayHours = (minutes / 60) % 24;
        int displayDays = minutes / 1440;

        Debug.Log($"{displayDays} days, {displayHours} hours, {displayMinutes} minutes.");
    }

    [ExecuteInEditMode]
    public void CalculateHours()
    {
        ClearLog();

        int displayHours = hours % 24;
        int displayDays = hours / 24;

        Debug.Log($"{displayDays} days, {displayHours} hours.");
    }

    private void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
