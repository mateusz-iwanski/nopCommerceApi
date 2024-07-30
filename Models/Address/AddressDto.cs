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
        public virtual int? Id { get; set; }
        /// <summary>
        /// Gets the first name
        /// </summary>
        public virtual string? FirstName { get; set; }

        /// <summary>
        /// Gets the last name
        /// </summary>
        public virtual string? LastName { get; set; }

        /// <summary>
        /// Gets the email
        /// </summary>
        [EmailAddress]
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets the company
        /// </summary>
        public virtual string? Company { get; set; }

        /// <summary>
        /// Gets the county
        /// </summary>
        public virtual string? County { get; set; }

        /// <summary>
        /// Gets the city
        /// </summary>
        public virtual string? City { get; set; }

        /// <summary>
        /// Gets the address 1
        /// </summary>
        public virtual string? Address1 { get; set; }

        /// <summary>
        /// Gets the address 2
        /// </summary>
        public virtual string? Address2 { get; set; }

        /// <summary>
        /// Gets the zip/postal code
        /// </summary>
        public virtual string? ZipPostalCode { get; set; }

        /// <summary>
        /// Gets the phone number
        /// </summary>
        public virtual string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets the fax number
        /// </summary>
        public virtual string? FaxNumber { get; set; }

        
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

        public static bool IsEnterpriseAddress(Entities.Usable.Address address, DbSet<AddressAttribute> addressAtributeDbSet)
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
