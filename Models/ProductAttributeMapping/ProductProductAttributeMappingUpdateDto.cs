﻿using System.Text.Json.Serialization;

namespace nopCommerceApi.Models.ProductAttributeMapping
{
    public class ProductProductAttributeMappingUpdateDto : ProductProductAttributeMappingDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
