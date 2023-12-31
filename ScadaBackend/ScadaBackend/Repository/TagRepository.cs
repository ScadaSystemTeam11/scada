using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ScadaBackend.Data;
using ScadaBackend.DTOs;
using ScadaBackend.Hub;
using ScadaBackend.Models;

namespace ScadaBackend.Repository;

public class TagRepository : ITagRepository
{
    private readonly ScadaContext _context;

    public TagRepository(ScadaContext context)
    {
        _context = context;
    }

    public async Task<DigitalInput> GetDigitalInputById(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            return await _context.DigitalInputs.FindAsync(id);
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<AnalogInput> GetAnalogInputById(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            return await _context.AnalogInputs.FindAsync(id);
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<bool> SetScanForDigitalInput(DigitalInput digitalInput, bool scan)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            digitalInput.OnOffScan = scan;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        } 
        finally{DbSemaphore.Release();}
    }
    
    public async Task<bool> SetScanForAnalogInput(AnalogInput analogInput, bool scan)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            analogInput.OnOffScan = scan;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        } 
        finally{DbSemaphore.Release();}
    }

    public async Task<List<AnalogInput>> GetAnalogInputTags()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            return await _context.AnalogInputs.ToListAsync();
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<List<DigitalInput>> GetDigitalInputTags()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            return await _context.DigitalInputs.ToListAsync();
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<List<DigitalOutput>> GetDigitalOutputs()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            return await _context.DigitalOutputs.ToListAsync();
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<List<AnalogOutput>> GetAnalogOutputs()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            return await _context.AnalogOutputs.ToListAsync();
        }
        finally{DbSemaphore.Release();}    }


    public async Task<DigitalOutputDTO> CreateDigitalOutput(DigitalOutputDTO digitalOutputDto)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            DigitalOutput di = new DigitalOutput(digitalOutputDto);
            await _context.AddAsync(di);
            await _context.SaveChangesAsync();
            return digitalOutputDto;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally{DbSemaphore.Release();}
    }

    
    public async Task<AnalogOutputDTO> CreateAnalogOutput(AnalogOutputDTO analogOutputDto)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            AnalogOutput analogOutput = new AnalogOutput(analogOutputDto);
            await _context.AddAsync(analogOutput);
            await _context.SaveChangesAsync();
            return analogOutputDto;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<AnalogInput> CreateAnalogInput(AnalogInputDTO analogInputDto)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            AnalogInput analogInput = new AnalogInput(analogInputDto);
            await _context.AddAsync(analogInput);
            await _context.SaveChangesAsync();

            return analogInput;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<DigitalInput> CreateDigitalInput(DigitalInputDTO digitalInputDto)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            DigitalInput digitalInput = new DigitalInput(digitalInputDto);
            await _context.AddAsync(digitalInput);
            await _context.SaveChangesAsync();

            return digitalInput;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } finally{ DbSemaphore.Release();}
    }

    public async Task UpdateAnalogInput(AnalogInput analogInput)
    {
        await DbSemaphore.WaitAsync();
        try
        {

            var ai = await _context.AnalogInputs.FindAsync(analogInput.ID);
            if (ai != null)
            {
                ai.CurrentValue = analogInput.CurrentValue;
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<bool> UpdateAnalogOutput( Guid id, int value)
    {
        await DbSemaphore.WaitAsync();
        try
        {

            var ai = await _context.AnalogOutputs.FindAsync(id);
            if (ai != null)
            {
                ai.CurrentValue = value;
                TagChange tagChange = new TagChange(ai, value, ai.IOAddress);
                _context.TagChanges.Add(tagChange);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;

        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<bool> UpdateDigitalOutput(Guid id, int value)
    {
        await DbSemaphore.WaitAsync();
        try
        {

            var ai = await _context.DigitalOutputs.FindAsync(id);
            if (ai != null)
            {
                ai.CurrentValue = value;
                TagChange tagChange = new TagChange(ai, value, ai.IOAddress);
                _context.TagChanges.Add(tagChange);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            DbSemaphore.Release();
        }
    }



    public async Task UpdateDigitalInput(DigitalInput digitalInput)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var di = await _context.DigitalInputs.FindAsync(digitalInput.ID);
            Console.WriteLine(di);
            if (di != null)
            {
                di.CurrentValue = digitalInput.CurrentValue;
                await _context.SaveChangesAsync();
     
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task CreateTagChange(TagChange tagChange)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            
            _context.TagChanges.Add(tagChange);
            await _context.SaveChangesAsync();
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<bool> RemoveDigitalInput(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var di = await _context.DigitalInputs.FindAsync(id);
            if (di != null)
            {
                di.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<bool> RemoveDigitalOutput(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var di = await _context.DigitalOutputs.FindAsync(id);
            if (di != null)
            {
                di.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<bool> RemoveAnalogInput(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var di = await _context.AnalogInputs.FindAsync(id);
            if (di != null)
            {
                di.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<bool> RemoveAnalogOutput(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var di = await _context.AnalogOutputs.FindAsync(id);
            if (di != null)
            {
                di.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        finally{DbSemaphore.Release();}    }

    public async Task<DigitalOutput> GetDigitalOutputById(Guid id)
    {
        return await _context.DigitalOutputs.FindAsync(id);
    }

    public async Task<AnalogOutput> GetAnalogOutputById(Guid id)
    {
        return await _context.AnalogOutputs.FindAsync(id);
    }

    public async Task<List<Tag>> GetActiveInputTags()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var digitalInputs = await _context.DigitalInputs
                .Where(di => di.OnOffScan == true && di.IsDeleted == false)
                .ToListAsync();

            var analogInputs = await _context.AnalogInputs
                .Where(ai => ai.OnOffScan == true && ai.IsDeleted == false)
                .ToListAsync();

            List<Tag> activeInputTags = new List<Tag>();
            activeInputTags.AddRange(digitalInputs);
            activeInputTags.AddRange(analogInputs);

            return activeInputTags;
        }
        finally
        {
            DbSemaphore.Release();
        }


    }

    public async Task<List<AnalogInputLastValueDTO>> GetLastValuesOfAITags()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var analogInputTags = await _context.AnalogInputs.ToListAsync();
            var analogInputLastValues = new List<AnalogInputLastValueDTO>();

            foreach (var analogInput in analogInputTags)
            {
                var latestTagChange = await _context.TagChanges
                    .Where(tc => tc.TagId == analogInput.ID)
                    .OrderByDescending(tc => tc.Timestamp)
                    .FirstOrDefaultAsync();

                if (latestTagChange != null)
                {
                    analogInputLastValues.Add(new AnalogInputLastValueDTO
                    {
                        AnalogInput = analogInput,
                        LastTagChange = latestTagChange
                    });
                }
            }

            return analogInputLastValues;
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<List<DigitalInputLastValueDTO>> GetLastValuesOfDITags()
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var digitalInputTags = await _context.DigitalInputs.ToListAsync();
            var digitalInputLastValues = new List<DigitalInputLastValueDTO>();

            foreach (var digitalInput in digitalInputTags)
            {
                var latestTagChange = await _context.TagChanges
                    .Where(tc => tc.TagId == digitalInput.ID)
                    .OrderByDescending(tc => tc.Timestamp)
                    .FirstOrDefaultAsync();

                if (latestTagChange != null)
                {
                    digitalInputLastValues.Add(new DigitalInputLastValueDTO
                    {
                        DigitalInput = digitalInput,
                        LastTagChange = latestTagChange
                    });
                }
            }

            return digitalInputLastValues;
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<List<TagChange>> GetTagsInTimePeriod(DateTime start, DateTime end)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var tagChangesInTimePeriod = await _context.TagChanges
                .Where(tc => tc.Timestamp >= start && tc.Timestamp <= end)
                .OrderByDescending(tc => tc.Timestamp)
                .ToListAsync();

            return tagChangesInTimePeriod;
        }
        finally
        {
            DbSemaphore.Release();
        }
    }

    public async Task<List<TagChange>> GetTagValuesById(Guid id)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            var tagChangesForTag = await _context.TagChanges
                .Where(tc => tc.TagId == id)
                .OrderByDescending(tc => tc.Timestamp)
                .ToListAsync();

            return tagChangesForTag;
        }
        finally
        {
            DbSemaphore.Release();
        }
    }




}
