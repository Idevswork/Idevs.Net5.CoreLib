using System;
using System.Collections.Generic;
using Serenity.Data;

namespace Idevs.Extensions
{
    public static class EntityQueryExtensions
    {
        /// <summary>
        ///   Sets all field values in a row with auto named parameters (field name prefixed with '@').</summary>
        /// <param field="row">
        ///   The row with modified field values. Must be in TrackAssignments mode, or an exception is raised.</param>
        /// <returns>
        ///   Object itself.</returns>
        public static T Set<T>(this T self, IRow row, params Field[] exclude) where T : ISetFieldByStatement
        {
            if (row == null)
                throw new ArgumentNullException("row");

            if (!row.TrackAssignments)
                throw new ArgumentException("row must be in TrackAssignments mode to determine modified fields.");

            var excludeFields =
                exclude is { Length: > 0 } ? new HashSet<Field>(exclude) : null;

            foreach (var field in row.Fields)
            {
                if (excludeFields != null && excludeFields.Contains(field)) continue;

                if (row.IsAssigned(field))
                {
                    self.Set(field, field.AsSqlValue(row));
                }
            }

            return self;
        }
    }
}
