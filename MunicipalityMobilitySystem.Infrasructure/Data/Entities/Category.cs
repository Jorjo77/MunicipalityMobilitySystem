﻿using System.ComponentModel.DataAnnotations;

using static MunicipalityMobilitySystem.Data.DataConstants.Category;
namespace MunicipalityMobilitySystem.Infrasructure.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int Size { get; set; }
        public IEnumerable<Bike> Bikes { get; set; } = new List<Bike>();
        public IEnumerable<Scooter> Scooters { get; set; } = new List<Scooter>();
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
        public IEnumerable<Truck> Trucks { get; set; } = new List<Truck>();
    }
}
