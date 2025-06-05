using IT_RunCourseSecondPartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IT_RunCourseSecondPartAPI.Interceptors;

public class DeletingUserInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int>
        SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            UpdateEntities(eventData.Context);
        }

        return base.SavingChanges(eventData, result);
    }

    private static void UpdateEntities(DbContext context)
    {
        var entityEntries = context.ChangeTracker.Entries<User>().ToList();

        foreach (var entry in entityEntries.Where(entry => entry.State == EntityState.Deleted))
        {
            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
        }
    }
}