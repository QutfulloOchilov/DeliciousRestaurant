using DeliciousRestaurant.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliciousRestaurant.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; protected set; }
    }
}