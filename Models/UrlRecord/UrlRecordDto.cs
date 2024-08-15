using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Entities.Usable;
using System.ComponentModel.DataAnnotations;

namespace nopCommerceApi.Models.UrlRecord
{
    /// <summary>
    /// UrlRecord is used to store SEO-friendly URLs for entities with an SEO category.
    /// </summary>
    public class UrlRecordDto : BaseDto
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// ## EntityName
        /// ### Gets or set the entity name
        /// #### Every entity which uses SEO friendly url, for example: Product, Category, Manufacturer, etc.
        /// </summary>
        [Required]
        public virtual string EntityName { get; set; } = null!;

        /// <summary>
        /// ## Slug 
        /// ### Gets or set friendly url
        /// </summary>
        [Required]
        public virtual string Slug { get; set; } = null!;

        /// <summary>
        /// ## EntityId
        /// ### Gets or set the entity id
        /// #### For example: if EntityName = "Product" then EntityId = ProductId
        /// </summary>
        [Required]
        public virtual int EntityId { get; set; }

        /// <summary>
        /// ## IsActive 
        /// ### Gets or set a value indicating whether the url record is active
        /// *Default = false*
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// ## LanguageId
        /// ### Gets or set the language identifier
        /// *Default = 0*
        /// </summary>
        public virtual int LanguageId { get; set; }        
    }
}
