﻿namespace NZWalks.API.Models.Dto
{
    public class CreateRegionDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
