namespace ScadaBackend.Data;

public class DbSemaphore
{
    private static SemaphoreSlim _dbSemaphore = new SemaphoreSlim(1);


    public static async Task WaitAsync()
    {
        await _dbSemaphore.WaitAsync();
    }

    public static void Release()
    {
        _dbSemaphore.Release();
    }
}
