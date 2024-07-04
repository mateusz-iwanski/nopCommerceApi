using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace nopCommerceApi.Models.Address
{
    public class AddressDto
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        [EmailAddress]
        public virtual string? Email { get; set; }
        public virtual string? Company { get; set; }        
        public virtual string? County { get; set; }
        public virtual string? City { get; set; }
        public virtual string? Address1 { get; set; }
        public virtual string? Address2 { get; set; }
        public virtual string? ZipPostalCode { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual string? FaxNumber { get; set; }
        public virtual string? CustomAttributes { get; set; }
        public DateTime CreatedOnUtc { get; set; }

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
    }

}
