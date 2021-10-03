/**
 * @author Kleber Ribeiro da Silva
 * @email krsmga@gmail.com
 * @create date 2020-06-17 20:09:59
 * @modify date 2021-10-03 16:30:03
 * @desc This class offers a clock to be used in a text component
 * @github https://github.com/krsmga/Clock
 */

using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// This class offers a clock to be used in a text component.
/// </summary>
public class Clock : MonoBehaviour
{
    [SerializeField] private FormatTime _formatTime = FormatTime.hhmm;
    [SerializeField] private bool _utcTime = false;
    [SerializeField] private bool _flashingDots = false;

    private enum FormatTime { hh, mm, ss, hhmm, mmss, hhmmss }; 
    private Text textTimeClock;
    private DateTime _dateTime;

    /// <summary>
    /// Returns the hour value in hh:hh:ss format
    /// </summary>
    /// <returns>
    /// (string) -> hh:mm:mm
    /// </returns>
    public string getTime
    {
        get 
        {
            if (_utcTime)
            {
                _dateTime = DateTime.UtcNow;
            } 
            else 
            {
                _dateTime = DateTime.Now;
            }

            string __hour = _dateTime.Hour.ToString().PadLeft(2, '0');
            string __minute = _dateTime.Minute.ToString().PadLeft(2, '0');
            string __seconds = _dateTime.Second.ToString().PadLeft(2, '0');
            string __result = "";
            string __dots = ":";

            if (_flashingDots && _dateTime.Second % 2 != 0)
            {
                __dots = " ";
            }

            if (_formatTime == FormatTime.hhmmss || 
                _formatTime == FormatTime.hhmm || 
                _formatTime == FormatTime.hh) 
            {
                __result+= __hour;
            }

            if (_formatTime == FormatTime.hhmmss || 
                _formatTime == FormatTime.mmss || 
                _formatTime == FormatTime.hhmm || 
                _formatTime == FormatTime.mm) 
            {
                __result+= (string.IsNullOrEmpty(__result) ? "" : __dots) + __minute;
            }

            if (_formatTime == FormatTime.hhmmss || 
                _formatTime == FormatTime.mmss || 
                _formatTime == FormatTime.ss) 
            {
                __result+= (string.IsNullOrEmpty(__result) ? "" : __dots) + __seconds;
            }

            return __result;
        }
    }

    void Start()
    {
        textTimeClock = GetComponent<Text>();
        InvokeRepeating("ClockUpdate",0f,1f);
    }

    private void ClockUpdate()
    {
        if (textTimeClock != null)
        {
            textTimeClock.text = getTime;
        }
    }
}
