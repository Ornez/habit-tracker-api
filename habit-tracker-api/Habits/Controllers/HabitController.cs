using habit_tracker_api.Accounts.Extensions;
using habit_tracker_api.Habits.DTOs;
using habit_tracker_api.Habits.Entities;
using habit_tracker_api.Shared.Controllers;
using habit_tracker_api.Shared.Data;
using habit_tracker_api.Shared.Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace habit_tracker_api.Habits.Controllers;

[Authorize]
public class HabitController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public HabitController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost("create-time-period")]
    public async Task<ActionResult<HabitDto>> CreateTimePeriod(CreateTimePeriodDto createTimePeriodDto)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());
        var habit = await _unitOfWork.HabitRepository.GetHabit(createTimePeriodDto.HabitId);

        if (habit == null)
        {
            return BadRequest($"Could not find habit with id {createTimePeriodDto.HabitId}");
        }

        if (habit.AppUser != user)
        {
            return BadRequest($"Failed to get habit with id {createTimePeriodDto.HabitId}, it's another's user habit");
        }

        Entities.TimePeriod timePeriod = new()
        {
            Habit = habit,
            Start = createTimePeriodDto.Start,
            End = createTimePeriodDto.End
        };

        habit.Occurrences.Add(timePeriod);
        _unitOfWork.HabitRepository.UpdateHabit(habit);

        if (await _unitOfWork.Complete())
        {
            Habit savedHabit = await _unitOfWork.HabitRepository.GetHabit(habit.Name, user);

            List<TimePeriodDto> occurrenceDtos = new();
            foreach(var occurrence in habit.Occurrences)
            {
                occurrenceDtos.Add(new TimePeriodDto()
                {
                    HabitId = occurrence.HabitId,
                    Start = occurrence.Start,
                    End = occurrence.End
                });
            }

            HabitDto habitDto = new()
            {
                Id = habit.Id,
                Name = habit.Name,
                Category = habit.Category,
                Hours = habit.Hours,
                Minutes = habit.Minutes,
                Frequency = habit.Frequency,
                Occurrences = occurrenceDtos
            };
            return Ok(habitDto);
        }
        return BadRequest("Failed to add time period");
    }

    [HttpPost]
    public async Task<ActionResult<HabitDto>> CreateHabit(CreateHabitDto createHabitDto)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());

        Habit habit = new()
        {
            AppUser = user,
            Name = createHabitDto.Name,
            Category = createHabitDto.Category,
            Hours = createHabitDto.Hours,
            Minutes = createHabitDto.Minutes,
            Frequency = createHabitDto.Frequency,
            Occurrences = new(),
        };

        _unitOfWork.HabitRepository.AddHabit(habit);

        if (await _unitOfWork.Complete())
        {
            Habit savedHabit = await _unitOfWork.HabitRepository.GetHabit(createHabitDto.Name, user);

            List<TimePeriodDto> occurrenceDtos = new();
            foreach (var occurrence in savedHabit.Occurrences)
            {
                occurrenceDtos.Add(new TimePeriodDto()
                {
                    HabitId = occurrence.HabitId,
                    Start = occurrence.Start,
                    End = occurrence.End
                });
            }

            HabitDto habitDto = new()
            {
                Id = savedHabit.Id,
                Name = savedHabit.Name,
                Category = savedHabit.Category,
                Hours = savedHabit.Hours,
                Minutes = savedHabit.Minutes,
                Frequency = savedHabit.Frequency,
                Occurrences = occurrenceDtos
            };
            return Ok(habitDto);
        }
        return BadRequest("Failed to create habit");
    }
     
    [HttpGet("{id}")]
    public async Task<ActionResult<HabitDto>> GetHabit(int id)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());
        var habit = await _unitOfWork.HabitRepository.GetHabit(id);

        if (habit == null)
        {
            return BadRequest($"Could not find habit with id {id}");
        }

        if (habit.AppUser != user)
        {
            return BadRequest($"Failed to get habit with id {id}, it's another's user habit");
        }

        List<TimePeriodDto> occurrenceDtos = new();
        foreach (var occurrence in habit.Occurrences)
        {
            occurrenceDtos.Add(new TimePeriodDto()
            {
                HabitId = occurrence.HabitId,
                Start = occurrence.Start,
                End = occurrence.End
            });
        }

        HabitDto habitDto = new()
        {
            Id = habit.Id,
            Name = habit.Name,
            Category = habit.Category,
            Hours = habit.Hours,
            Minutes = habit.Minutes,
            Frequency = habit.Frequency,
            Occurrences = occurrenceDtos
        };

        return Ok(habitDto);
    }

    [HttpGet]
    public async Task<ActionResult<List<HabitDto>>> GetHabits()
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());
        var habits = await _unitOfWork.HabitRepository.GetHabitsForUser(user);
        return Ok(habits);
    }

    [HttpPut]
    public async Task<ActionResult<HabitDto>> UpdateHabit(UpdateHabitDto updateHabitDto)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());
        var habit = await _unitOfWork.HabitRepository.GetHabit(updateHabitDto.Id);
        
        if (habit == null)
        {
            return BadRequest($"Could not find habit with id {updateHabitDto.Id}");
        }
        if (habit.AppUser != user)
        {
            return BadRequest($"Failed to update habit with id {updateHabitDto.Id}, it's another's user habit");
        }

        habit.Name = updateHabitDto.Name;
        habit.Category = updateHabitDto.Category;
        habit.Hours = updateHabitDto.Hours;
        habit.Minutes = updateHabitDto.Minutes;
        habit.Frequency = updateHabitDto.Frequency;

        _unitOfWork.HabitRepository.UpdateHabit(habit);

        if (await _unitOfWork.Complete())
        {
            List<TimePeriodDto> occurrenceDtos = new();
            foreach (var occurrence in habit.Occurrences)
            {
                occurrenceDtos.Add(new TimePeriodDto()
                {
                    HabitId = occurrence.HabitId,
                    Start = occurrence.Start,
                    End = occurrence.End
                });
            }

            HabitDto habitDto = new()
            {
                Id = habit.Id,
                Name = habit.Name,
                Category = habit.Category,
                Hours = habit.Hours,
                Minutes = habit.Minutes,
                Frequency = habit.Frequency,
                Occurrences = occurrenceDtos
            };

            return Ok(habitDto);
        }
        return BadRequest("Failed to update habit");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHabit(int id)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());
        var habit = await _unitOfWork.HabitRepository.GetHabit(id);

        if (habit == null)
        {
            return BadRequest($"Could not find habit with id {id}");
        }
        if (habit.AppUser != user)
        {
            return BadRequest($"Failed to delete habit with id {id}, it's another's user habit");
        }

        _unitOfWork.HabitRepository.DeleteHabit(habit);

        if (await _unitOfWork.Complete())
        {
            return Ok($"Habit with id {id} deleted successfully");
        }

        return BadRequest($"Failed to delete habit with id {id}");
    }
}
