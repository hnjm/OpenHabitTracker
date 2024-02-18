﻿namespace Ididit.Data.Models;

public class HabitModel : ItemsModel
{
    public int RepeatCount { get; set; }

    public int RepeatInterval { get; set; }

    public Period RepeatPeriod { get; set; }

    public TimeOnly? Duration { get; set; }

    public DateTime? LastTimeDoneAt { get; set; }

    public List<TimeModel>? TimesDone { get; set; }

    internal TimeSpan ElapsedTime => LastTimeDoneAt.HasValue ? DateTime.Now - LastTimeDoneAt.Value : DateTime.Now - CreatedAt;

    internal double ElapsedTimeToRepeatIntervalRatio => ElapsedTime / GetRepeatInterval() * 100.0;

    internal TimeOnly DurationProxy
    {
        get => Duration ?? TimeOnly.MinValue;
        set => Duration = value == TimeOnly.MinValue ? null : value;
    }

    internal Dictionary<DateTime, List<TimeModel>>? TimesDoneByDay { get; set; }

    public void RefreshTimesDoneByDay()
    {
        TimesDoneByDay = TimesDone?.GroupBy(date => date.StartedAt.Date).ToDictionary(group => group.Key, group => group.ToList());
    }

    public TimeSpan GetRepeatInterval()
    {
        return RepeatPeriod switch
        {
            Period.Day => TimeSpan.FromDays(RepeatInterval),
            Period.Week => TimeSpan.FromDays(7 * RepeatInterval),
            Period.Month => TimeSpan.FromDays(30 * RepeatInterval),
            Period.Year => TimeSpan.FromDays(365 * RepeatInterval),
            _ => throw new ArgumentOutOfRangeException(nameof(RepeatPeriod))
        };
    }

    public bool? IsOverdue() // TODO: add a field, call the method only when TimesDone changes
    {
        if (LastTimeDoneAt is null)
            return null;

        // TODO: use RepeatCount

        // do NOT use LastTimeDoneAt

        // only use TimesDone

        // sort it, because TimesDone can have elements in the past added later

        // iterate the list from the end, break if you find RepeatCount num of dates, or if you reach a date that is outside elapsedTime

        DateTime nextDueDate = RepeatPeriod switch
        {
            Period.Day => LastTimeDoneAt.Value.AddDays(RepeatInterval),
            Period.Week => LastTimeDoneAt.Value.AddDays(7 * RepeatInterval),
            Period.Month => LastTimeDoneAt.Value.AddMonths(RepeatInterval),
            Period.Year => LastTimeDoneAt.Value.AddYears(RepeatInterval),
            _ => throw new ArgumentOutOfRangeException(nameof(RepeatPeriod))
        };

        return nextDueDate < DateTime.Now;
    }
}
