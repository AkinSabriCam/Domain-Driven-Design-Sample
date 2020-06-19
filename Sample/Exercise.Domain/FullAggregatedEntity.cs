using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Domain
{
    public class FullAggregatedEntity<TId> : Entity<TId> where TId : IEquatable<TId>
    {
        public DateTime CreateTime { get; set; }
        
        public DateTime DeleteTime { get; set; }
    }
}
