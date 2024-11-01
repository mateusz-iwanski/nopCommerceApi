﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttributeValue
{
    public class ProductAttributeValueDtoCreate : ProductAttributeValueDto
    {
        [JsonIgnore]
        public override int Id { get; set; }

        [Required]
        [JsonIgnore]
        public override int ProductAttributeMappingId { get; set; }
    }
}
