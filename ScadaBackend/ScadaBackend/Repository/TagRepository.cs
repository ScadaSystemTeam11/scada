using Microsoft.EntityFrameworkCore;
using ScadaBackend.Data;
using ScadaBackend.DTOs;
using ScadaBackend.Models;
using AppContext = ScadaBackend.Data.AppContext;

namespace ScadaBackend.Repository;

public class TagRepository : ITagRepository
{
    private readonly AppContext _context;

    public TagRepository(AppContext context)
    {
        _context = context;
    }

    public async Task<DigitalInput> GetDigitalInputById(int id)
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

    public async Task<AnalogInput> GetAnalogInputById(int id)
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

    public async Task<AnalogInputDTO> CreateAnalogInput(AnalogInputDTO analogInputDto)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            AnalogInput analogInput = new AnalogInput(analogInputDto);
            await _context.AddAsync(analogInput);
            await _context.SaveChangesAsync();
            return analogInputDto;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally{DbSemaphore.Release();}
    }

    public async Task<DigitalInputDTO> CreateDigitalInput(DigitalInputDTO digitalInputDto)
    {
        await DbSemaphore.WaitAsync();
        try
        {
            DigitalInput digitalInput = new DigitalInput(digitalInputDto);
            await _context.AddAsync(digitalInput);
            await _context.SaveChangesAsync();

            return digitalInputDto;
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
                Console.WriteLine(ai);
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

    public async Task<bool> RemoveDigitalInput(int id)
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

    public async Task<bool> RemoveDigitalOutput(int id)
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

    public async Task<bool> RemoveAnalogInput(int id)
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

    public async Task<bool> RemoveAnalogOutput(int id)
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
}
