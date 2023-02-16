using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //public delegate void OnHourTick();
    //public static event OnHourTick hourTickSend;

    public delegate void OnDayTick();
    public static event OnDayTick dayTickSend;

    public delegate void OnWeekTick();
    public static event OnWeekTick weekTickSend;

    public delegate void OnMonthTick();
    public static event OnMonthTick monthTickSend;

    public delegate void OnYearTick();
    public static event OnYearTick yearTickSend;

    public int hour;
    public int day;
    public int weekDay;
    public int month;
    public int year;

    private static readonly int[] daysPerMonth = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    private float timeMultiplier;

    private float timeSinceTick;

    void Start()
    {
        hour = 0;
        day = 1;
        weekDay = 1;
        month = 1;
        year = 1180;

        timeMultiplier = 100;
    }

    private void Update()
    {
        timeSinceTick += Time.deltaTime * timeMultiplier;

        while (timeSinceTick >= 1f)
        {
            timeSinceTick -= 1f;
            HourTick();
        }
    }

    public void HourTick()
    {
        hour += 1;

        if (hour >= 24)
        {
            DayTick();
        }
    }

    public void DayTick()
    {
        hour = 0;
        day += 1;
        weekDay++;
        int maxDays = daysPerMonth[month - 1];

        if (month == 2 && year % 4 == 0)
        {
            maxDays = 29;
        }

        if (day > maxDays)
        {
            MonthTick();
        }

        if (weekDay > 6)
        {
            WeekTick();
        }

        dayTickSend?.Invoke();
    }

    public void WeekTick()
    {
        weekDay = 1;
        weekTickSend.Invoke();
    }

    public void MonthTick()
    {
        day = 1;
        month += 1;

        if (month > 12)
        {
            YearTick();
        }

        monthTickSend?.Invoke();
    }

    public void YearTick()
    {
        month = 1;
        year += 1;

        yearTickSend?.Invoke();
    }
}