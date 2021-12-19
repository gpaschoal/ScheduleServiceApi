using System.Linq.Expressions;

namespace ScheduleService.Infrastructure.Context.Contexts;

internal static class ScheduleServiceExtensions
{
    public static void SetValue<TEntity, TProperty>(this TEntity entity, Expression<Func<TEntity, TProperty>> expression, TProperty newValue) where TEntity : class
    {
        var memberExpression = (MemberExpression)expression.Body;
        var propName = memberExpression.Member.Name;
        var prop = entity.GetType().GetProperty(propName);
        prop?.SetValue(entity, newValue);
    }
}
