using System;
using System.ComponentModel.DataAnnotations;

namespace YS.CMS.Domain.Base.Entities
{
    public abstract class EntityBase 
    {
        [Key]
        public Guid Id { get; protected set; }
    }
}
