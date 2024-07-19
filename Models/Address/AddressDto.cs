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

    public class AddressDto : BaseDto
    {
        // If we not set/get Email over private _email, we will get an error 'Access violation' from IIS
        private string _email;  

        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        [EmailAddress]
        public virtual string Email
        {
            get => _email;
            set => _email = value?.Trim();
        }

        public virtual string? Company { get; set; }        
        public virtual string? County { get; set; }
        public virtual string? City { get; set; }
        public virtual string? Address1 { get; set; }
        public virtual string? Address2 { get; set; }
        public virtual string? ZipPostalCode { get; set; }
        public virtual string? PhoneNumber { get; set; }
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
