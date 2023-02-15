﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityMobilitySystem.Core.Models.Admin
{
    public class WashingCenterServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Adress { get; set; } = null!;

    }
}
