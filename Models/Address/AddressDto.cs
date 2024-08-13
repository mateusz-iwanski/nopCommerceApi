using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using Microsoft.Extensions.Primitives;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Models.Address
{
    /// <summary>
    /// Address Data Transfer Object
    /// </summary>
    /// <remarks>
    /// This object should be used only for the get method in controller
    /// </remarks>
    public class AddressDto : BaseDto
    {
        /// <summary>
        /// ## Id
        /// ### Gets or sets the entity identifier
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// ## CountryId
        /// ### Gets or sets the country identifier
        /// </summary>
        public virtual int? CountryId { get; set; }

        /// <summary>
        /// ## StateProvinceId
        /// ### Gets or sets the state/province identifier
        /// *Defaul = null*
        /// </summary>
        public virtual int? StateProvinceId { get; set; }

        /// <summary>
        /// ## FirstName
        /// ### Gets or sets the first name
        /// *Defaul = null*
        /// </summary>
        public virtual string? FirstName { get; set; }

        /// <summary>
        /// ## LastName
        /// ### Gets or sets the last name
        /// *Defaul = null*
        /// </summary>
        public virtual string? LastName { get; set; }

        /// <summary>
        /// ## Email
        /// ## Gets or sets the email
        /// *Defaul = null*
        /// </summary>
        [EmailAddress]
        public virtual string? Email { get; set; }

        /// <summary>
        /// ## Company
        /// ### Gets or sets the company        
        /// *Defaul = null*
        /// </summary>
        public virtual string? Company { get; set; }

        /// <summary>
        /// ## County
        /// ### Gets or sets the county
        /// *Defaul = null*
        /// </summary>
        public virtual string? County { get; set; }

        /// <summary>
        /// ## City
        /// ### Gets or sets the city
        /// *Defaul = null*
        /// </summary>
        [Required]
        public virtual string? City { get; set; }

        /// <summary>
        /// ## Address1
        /// ### Gets or sets the address 1
        /// *Defaul = null*
        /// </summary>
        [Required]
        public virtual string? Address1 { get; set; }

        /// <summary>
        /// ## Address2
        /// ### Gets or sets the address 2
        /// *Defaul = null*
        /// </summary>
        public virtual string? Address2 { get; set; }

        /// <summary>
        /// ## ZipPostalCode
        /// ### Gets or sets the zip/postal code
        /// *Defaul = null*
        /// </summary>
        public virtual string? ZipPostalCode { get; set; }

        /// <summary>
        /// ## PhoneNumber
        /// ### Gets or sets the phone number
        /// *Defaul = null*
        /// </summary>
        public virtual string? PhoneNumber { get; set; }

        /// <summary>
        /// ## FaxNumber
        /// ### Gets or sets the fax number
        /// *Defaul = null*
        /// </summary>
        public virtual string? FaxNumber { get; set; }

        /// <summary>
        /// ## CustomAttributes
        /// ### Gets or sets the custom attributes (see "AddressAttribute" entity for more info).
        /// #### It's in XML Format
        /// *Defaul = null*
        /// </summary>
        [JsonIgnore]
        public virtual string? CustomAttributes { get; set; }

        /// <summary>
        /// ## CreatedOnUtc        
        /// ### Gets or sets the date and time of instance creation
        /// *Defaul = DateTime.Now*
        /// </summary>
        [JsonIgnore]
        public virtual DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// Get Value from CustomAttributes
        /// 
        /// Custom attribute is stored in XML format
        /// </summary>
        /// <param name="customAttribute">Data in xml format</param>
        /// <returns></returns>
        public static string? GetValueFromCustomAttribute(string customAttribute)
        {

            if (string.IsNullOrWhiteSpace(customAttribute))
                return default;
            else
            {
                try
                {
                    XmlDocument doc = new XmlDocument();

                    string xml = customAttribute;

                    doc.LoadXml(xml);

                    // query to select the <Value> node
                    XmlNode valueNode = doc.SelectSingleNode("//Value");

                    return valueNode != null ? valueNode.InnerText : null;
                }
                catch (XmlException)
                {
                    return default;
                }
            }
        }

        public static bool IsEnterpriseAddress(Entities.Usable.Address address, DbSet<Entities.Usable.AddressAttribute> addressAtributeDbSet)
        {
            string xmlString = address.CustomAttributes;

            if (!string.IsNullOrEmpty(xmlString))
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.LoadXml(xmlString);

                if (string.IsNullOrEmpty(xmlString))
                    return false;

                var addressAttribute = addressAtributeDbSet
                    .FirstOrDefault(c => c.Name == "NIP" && c.AttributeControlTypeId == 4);

                // Specify the ID you're looking for
                int attributeId = addressAttribute.Id;
                XmlNode addressAttributeNode = xmlDoc.SelectSingleNode($"/Attributes/AddressAttribute[@ID='{attributeId}']");

                if (addressAttributeNode != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }

}
