using MauiHybridAuthentication.Entities;
using SQLite;

namespace MauiHybridAuthentication.Repositories;

public class UserAccountRepository
{
    private readonly SQLiteAsyncConnection _connection;

    public UserAccountRepository(SQLiteAsyncConnection connection)
    {
        _connection = connection;
        Task.Run(DeployTable);
    }

    public async Task<List<UserAccount>> Get() =>
        await _connection.Table<UserAccount>().ToListAsync();

    public async Task<UserAccount> Get(string userName) =>
         await _connection.Table<UserAccount>().Where(x => x.UserName == userName).FirstOrDefaultAsync();

    public async Task Create(UserAccount entity) =>
        await _connection.InsertAsync(entity);

    public async Task Update(UserAccount entity) =>
        await _connection.UpdateAsync(entity);

    public async Task Delete(UserAccount entity) =>
        await _connection.DeleteAsync(entity);

    private async Task DeployTable()
    {
        await _connection.CreateTableAsync<UserAccount>();
        var adminUser = await _connection.Table<UserAccount>().Where(x => x.UserName == "admin").FirstOrDefaultAsync();
        if (adminUser is null)
        {
            adminUser = new UserAccount
            {
                FirstName = "Administrator",
                LastName = null,
                UserName = "admin",
                Password = "admin123",
                Role = "Administrator"
            };
            await _connection.InsertAsync(adminUser);
        }
    }
}
