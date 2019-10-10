using System;

namespace SharedKernel.CleverbitSoftware
{
    public abstract class Entity
    {
        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            if (Equals(id, default(Guid)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", nameof(id));
            }

            Id = id;
        }

        public Guid Id { get; set; }
    }
}