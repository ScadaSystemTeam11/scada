using Microsoft.EntityFrameworkCore;
using ScadaBackend.Data;
using ScadaBackend.DTOs;
using ScadaBackend.Interfaces;
using ScadaBackend.Models;
using AppContext = ScadaBackend.Data.AppContext;


namespace ScadaBackend.Repository
{
    public class AlarmRepository : IAlarmRepository
    {
        private readonly AppContext _context;

        public AlarmRepository(AppContext context)
        {
            _context = context;
        }

        public async void AddAlarm(Alarm newAlarm)
        {
            await DbSemaphore.WaitAsync();
            try
            {
                await _context.Alarms.AddAsync(newAlarm);
                await _context.SaveChangesAsync();
                return;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally { DbSemaphore.Release(); }
        }

        public async Task<Alarm> GetAlarmById(Guid id)
        {
            await DbSemaphore.WaitAsync();
            try
            {
                return await _context.Alarms.FindAsync(id);
            }
            finally
            {
                DbSemaphore.Release();
            }
        }

        public async Task<bool> RemoveAlarm(Guid id)
        {
            await DbSemaphore.WaitAsync();
            try
            {
                var alarm = await _context.Alarms.FindAsync(id);
                if (alarm != null)
                {
                    alarm.IsDeleted = true;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            finally { DbSemaphore.Release(); }
        }

        public async Task AddAlarmAlert(AlarmAlert alarmAlert)
        {
            await DbSemaphore.WaitAsync();
            try
            {
                alarmAlert.Timestamp = alarmAlert.Timestamp.ToUniversalTime();
                _context.AlarmAlerts.Add(alarmAlert);
                await _context.SaveChangesAsync();

            }
            finally
            {
                DbSemaphore.Release();
            }

        }
    }
}
