using Acme.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Data;

public class SnakeRepository : IRepository<SnakeInfo, Guid>
{
    private readonly AppDbContext context;

    public SnakeRepository(AppDbContext context) => this.context = context;

    private DbSet<SnakeInfo> Snakes => this.context.Snakes!;

    private DatabaseFacade Database => this.context.Database!;

    ///////  Create  /////////


    public Task<SnakeInfo> Create(SnakeInfo original)
        => this.Create_SqlRaw(original);

    private async Task<SnakeInfo> Create_EF(SnakeInfo original)
    {
        var result = await this.Snakes.AddAsync(original);
        await this.context.SaveChangesAsync();
        return result.Entity;
    }

    private async Task<SnakeInfo> Create_SqlRaw(SnakeInfo original)
    {
        var sql =
            $@"
            INSERT [App].[{nameof(SnakeInfo)}]
            VALUES ('{original.ID}', '{original.Name}', '{original.Color}',{original.MeannessLevel}, '{original.PayGrade}');";

        var _ = await this.Database.ExecuteSqlRawAsync(sql);
        return await this.Snakes.SingleAsync(s => s.ID == original.ID);
    }

    private async Task<SnakeInfo> Create_DBCommand(SnakeInfo original)
    {
        using var connection = this.Database.GetDbConnection();
        using var command = connection.CreateCommand();
        command.CommandText =
            $@"
            INSERT [App].[Snake]
            VALUES (@id, @name, @color,@meanness,@paygrade);";

        var idParameter = command.CreateParameter();
        idParameter.ParameterName = "id";
        idParameter.Value = original.ID.ToString();
        idParameter.DbType = System.Data.DbType.String;
        command.Parameters.Add(idParameter);

        var nameParameter = command.CreateParameter();
        nameParameter.ParameterName = "name";
        nameParameter.Value = original.Name;
        nameParameter.DbType = System.Data.DbType.String;
        command.Parameters.Add(nameParameter);

        var colorParameter = command.CreateParameter();
        colorParameter.ParameterName = "color";
        colorParameter.Value = original.Color;
        colorParameter.DbType = System.Data.DbType.String;
        command.Parameters.Add(colorParameter);

        var meannessParameter = command.CreateParameter();
        meannessParameter.ParameterName = "meanness";
        meannessParameter.Value = original.MeannessLevel;
        meannessParameter.DbType = System.Data.DbType.Int32;
        command.Parameters.Add(meannessParameter);

        var payGradeParameter = command.CreateParameter();
        payGradeParameter.ParameterName = "paygrade";
        payGradeParameter.Value = original.PayGrade;
        payGradeParameter.DbType = System.Data.DbType.String;
        command.Parameters.Add(payGradeParameter);


        await connection.OpenAsync();
        var _ = await command.ExecuteNonQueryAsync();
        return original;
    }

    //////  \create  //////////



    public async Task<SnakeInfo> Update(SnakeInfo updated)
    {
        var persisted = this.Snakes.Update(updated);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public async Task<SnakeInfo?> Remove(Guid id)
    {
        var original = await this.Snakes.SingleOrDefaultAsync(r => r.ID == id);
        if (original == null)
        {
            return null;
        }

        var persisted = this.Snakes.Remove(original);
        await this.context.SaveChangesAsync();
        return persisted.Entity;
    }

    public Task<SnakeInfo?> Get(Guid id) => this.Snakes.SingleOrDefaultAsync(r => r.ID == id);

    public async Task<IEnumerable<SnakeInfo>> Get()
    {
        var results = await this.Snakes.ToListAsync();
        return results;
    }
}
