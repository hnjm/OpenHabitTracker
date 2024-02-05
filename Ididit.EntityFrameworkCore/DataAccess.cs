﻿using Ididit.Data;
using Ididit.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ididit.EntityFrameworkCore;

public class DataAccess : IDataAccess
{
    private readonly ApplicationDbContext _dataContext;

    public DataAccess(ApplicationDbContext dataContext)
    {
        _dataContext = dataContext;
        _dataContext.Database.EnsureCreated();
    }

    public async Task Initialize()
    {
        await _dataContext.Database.EnsureCreatedAsync();
    }

    public async Task AddHabit(HabitEntity habit)
    {
        _dataContext.Add(habit);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddNote(NoteEntity note)
    {
        _dataContext.Add(note);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddTask(TaskEntity task)
    {
        _dataContext.Add(task);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddTime(TimeEntity time)
    {
        _dataContext.Add(time);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddItem(ItemEntity item)
    {
        _dataContext.Add(item);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddCategory(CategoryEntity category)
    {
        _dataContext.Add(category);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddPriority(PriorityEntity priority)
    {
        _dataContext.Add(priority);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddSettings(SettingsEntity settings)
    {
        _dataContext.Add(settings);
        await _dataContext.SaveChangesAsync();
    }

    public async Task AddHabits(IReadOnlyCollection<HabitEntity> habits)
    {
        _dataContext.AddRange(habits);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddNotes(IReadOnlyCollection<NoteEntity> notes)
    {
        _dataContext.AddRange(notes);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddTasks(IReadOnlyCollection<TaskEntity> tasks)
    {
        _dataContext.AddRange(tasks);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddTimes(IReadOnlyCollection<TimeEntity> times)
    {
        _dataContext.AddRange(times);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddItems(IReadOnlyCollection<ItemEntity> items)
    {
        _dataContext.AddRange(items);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddCategories(IReadOnlyCollection<CategoryEntity> categories)
    {
        _dataContext.AddRange(categories);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddPriorities(IReadOnlyCollection<PriorityEntity> priorities)
    {
        _dataContext.AddRange(priorities);
        await _dataContext.SaveChangesAsync();
    }
    public async Task AddSettings(IReadOnlyCollection<SettingsEntity> settings)
    {
        _dataContext.AddRange(settings);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<HabitEntity>> GetHabits()
    {
        return await _dataContext.Habits.ToListAsync();
    }
    public async Task<IReadOnlyList<NoteEntity>> GetNotes()
    {
        return await _dataContext.Notes.ToListAsync();
    }
    public async Task<IReadOnlyList<TaskEntity>> GetTasks()
    {
        return await _dataContext.Tasks.ToListAsync();
    }
    public async Task<IReadOnlyList<TimeEntity>> GetTimes(long? habitId = null)
    {
        if (habitId is null)
            return await _dataContext.Times.ToListAsync();
        else
            return await _dataContext.Times.Where(t => t.HabitId == habitId).ToListAsync();
    }
    public async Task<IReadOnlyList<ItemEntity>> GetItems(long? parentId = null)
    {
        if (parentId is null)
            return await _dataContext.Items.ToListAsync();
        else
            return await _dataContext.Items.Where(i => i.ParentId == parentId).ToListAsync();
    }
    public async Task<IReadOnlyList<CategoryEntity>> GetCategories()
    {
        return await _dataContext.Categories.ToListAsync();
    }
    public async Task<IReadOnlyList<PriorityEntity>> GetPriorities()
    {
        return await _dataContext.Priorities.ToListAsync();
    }
    public async Task<IReadOnlyList<SettingsEntity>> GetSettings()
    {
        return await _dataContext.Settings.ToListAsync();
    }

    public async Task<HabitEntity?> GetHabit(long id)
    {
        return await _dataContext.Habits.FindAsync(id);
    }
    public async Task<NoteEntity?> GetNote(long id)
    {
        return await _dataContext.Notes.FindAsync(id);
    }
    public async Task<TaskEntity?> GetTask(long id)
    {
        return await _dataContext.Tasks.FindAsync(id);
    }
    public async Task<TimeEntity?> GetTime(long id)
    {
        return await _dataContext.Times.FindAsync(id);
    }
    public async Task<ItemEntity?> GetItem(long id)
    {
        return await _dataContext.Items.FindAsync(id);
    }
    public async Task<CategoryEntity?> GetCategory(long id)
    {
        return await _dataContext.Categories.FindAsync(id);
    }
    public async Task<PriorityEntity?> GetPriority(long id)
    {
        return await _dataContext.Priorities.FindAsync(id);
    }
    public async Task<SettingsEntity?> GetSettings(long id)
    {
        return await _dataContext.Settings.FindAsync(id);
    }

    public async Task UpdateHabit(HabitEntity habit)
    {
        habit.UpdatedAt = DateTime.UtcNow;
        _dataContext.Update(habit);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdateNote(NoteEntity note)
    {
        note.UpdatedAt = DateTime.UtcNow;
        _dataContext.Update(note);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdateTask(TaskEntity task)
    {
        task.UpdatedAt = DateTime.UtcNow;
        _dataContext.Update(task);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdateTime(TimeEntity time)
    {
        _dataContext.Update(time);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdateItem(ItemEntity item)
    {
        _dataContext.Update(item);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdateCategory(CategoryEntity category)
    {
        _dataContext.Update(category);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdatePriority(PriorityEntity priority)
    {
        _dataContext.Update(priority);
        await _dataContext.SaveChangesAsync();
    }
    public async Task UpdateSettings(SettingsEntity settings)
    {
        _dataContext.Update(settings);
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveHabit(long id)
    {
        _dataContext.Remove(new HabitEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemoveNote(long id)
    {
        _dataContext.Remove(new NoteEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemoveTask(long id)
    {
        _dataContext.Remove(new TaskEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemoveTime(long id)
    {
        _dataContext.Remove(new TimeEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemoveItem(long id)
    {
        _dataContext.Remove(new ItemEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemoveCategory(long id)
    {
        _dataContext.Remove(new CategoryEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemovePriority(long id)
    {
        _dataContext.Remove(new PriorityEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }
    public async Task RemoveSettings(long id)
    {
        _dataContext.Remove(new SettingsEntity { Id = id });
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveHabits()
    {
        await _dataContext.Habits.ExecuteDeleteAsync();
    }
    public async Task RemoveNotes()
    {
        await _dataContext.Notes.ExecuteDeleteAsync();
    }
    public async Task RemoveTasks()
    {
        await _dataContext.Tasks.ExecuteDeleteAsync();
    }
    public async Task RemoveTimes()
    {
        await _dataContext.Times.ExecuteDeleteAsync();
    }
    public async Task RemoveItems()
    {
        await _dataContext.Items.ExecuteDeleteAsync();
    }
    public async Task RemoveCategories()
    {
        await _dataContext.Categories.ExecuteDeleteAsync();
    }
    public async Task RemovePriorities()
    {
        await _dataContext.Priorities.ExecuteDeleteAsync();
    }
    public async Task RemoveSettings()
    {
        await _dataContext.Settings.ExecuteDeleteAsync();
    }
}
