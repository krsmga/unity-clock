/**
 * @author Kleber Ribeiro da Silva
 * @email krsmga@gmail.com
 * @create date 2020-06-17 20:09:59
 * @modify date 2020-06-17 21:19:03
 * @desc This class offers a clock to be used in a text component
 * @github https://github.com/krsmga/Clock
 */

using UnityEngine;
using TMPro;
using System;

/// <summary>
/// This class offers a clock to be used in a text component.
/// </summary>
public class Clock : MonoBehaviour
{
    private TextMeshProUGUI textTimeClock;
    private DateTime _dateTime;

    /// <summary>
    /// Returns the hour value in hh:mm format
    /// </summary>
    /// <returns>
    /// (string) -> hh:mm
    /// </returns>
    public string TimeHM
    {
        get 
        {
            _dateTime = DateTime.Now;
            string hour = _dateTime.Hour.ToString().PadLeft(2, '0');
            string minute = _dateTime.Minute.ToString().PadLeft(2, '0');
            return hour + ":" + minute;
        }
    }

    /// <summary>
    /// Returns the hour value in hh:hh:ss format
    /// </summary>
    /// <returns>
    /// (string) -> hh:mm:mm
    /// </returns>
    public string TimeHMS
    {
        get 
        {
            _dateTime = DateTime.Now;
            string hour = _dateTime.Hour.ToString().PadLeft(2, '0');
            string minute = _dateTime.Minute.ToString().PadLeft(2, '0');
            string seconds = _dateTime.Second.ToString().PadLeft(2, '0');
            return hour + ":" + minute + ":" + seconds;
        }
    }

    void Start()
    {
        textTimeClock = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("ClockUpdate",0f,20f);
    }

    private void ClockUpdate()
    {
        if (textTimeClock != null)
        {
            textTimeClock.text = TimeHM;
        }
    }
}
