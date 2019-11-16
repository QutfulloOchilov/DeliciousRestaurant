using DeliciousRestaurant.Domain.Interfaces;
using System;

namespace DeliciousRestaurant.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; protected set; }
    }
}