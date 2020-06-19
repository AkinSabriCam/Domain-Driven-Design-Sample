using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Domain
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; set; }
    }
}
