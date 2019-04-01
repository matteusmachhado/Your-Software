using System;

namespace YS.CMS.Domain.Entities
{
    public abstract class EntityBase 
    {
        public Guid Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = Guid.NewGuid();
            }
        }
    }
}
