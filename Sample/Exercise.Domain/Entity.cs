using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Domain
{
    public class Entity<TId> : IBaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
