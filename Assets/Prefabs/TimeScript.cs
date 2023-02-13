using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public delegate void OnMonthTick();
    public static event OnMonthTick monthTickSend;

    public int hour;
    public int day;
    public int month;
    public int year;

    private int[] daysPerMonth;

    private float timeMultiplier = 100f;

    private float timeSinceTick;

    void Start()
    {
        hour = 0;
        day = 1;
        month = 1;
        year = 1180;

        daysPerMonth = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    }

    private void Update()
    {
        timeSinceTick += Time.deltaTime * timeMultiplier;

        while (timeSinceTick >= 1f)
        {
            timeSinceTick -= 1f;
            hourTick();
        }
    }

    public void hourTick()
    {
        hour += 1;

        if (hour >= 24)
        {
            dayTick();
        }
    }

    public void dayTick()
    {
        hour = 0;
        day += 1;

        int maxDays = daysPerMonth[month - 1];

        if (month == 2 && year % 4 == 0)
        {
            maxDays = 29;
        }

        if (day > maxDays)
        {
            monthTick();
        }
    }

    public void monthTick()
    {
        day = 1;
        month += 1;

        if (month > 12)
        {
            yearTick();
        }

        if (monthTickSend != null)
        {
            monthTickSend();
        }
    }

    public void yearTick()
    {
        month = 1;
        year += 1;
    }
}