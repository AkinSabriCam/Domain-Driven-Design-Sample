using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Domain
{
    public class FullAggregatedEntity<TId> : IBaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; set; }

        public DateTime CreateTime { get; set; }
        
        public DateTime DeleteTime { get; set; }
    }
}
