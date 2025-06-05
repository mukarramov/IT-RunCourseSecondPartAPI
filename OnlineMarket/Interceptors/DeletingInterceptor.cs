using IT_RunCourseSecondPartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IT_RunCourseSecondPartAPI.Interceptors;

public class DeletingInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int>
        SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            DeleteEntities(eventData.Context);
        }

        return base.SavingChanges(eventData, result);
    }

    private static void DeleteEntities(DbContext context)
    {
        var entityEntries = context.ChangeTracker.Entries<IEntity>().ToList();

        foreach (var entry in entityEntries.Where(entry => entry.State == EntityState.Deleted))
        {
            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
        }
    }
}