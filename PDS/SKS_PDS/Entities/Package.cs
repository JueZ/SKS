using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SKS_PDS.Entities
{
    public class Package
    {
        [Key]
        public int PackageID
        {
            get;
            set;
        }
        public string Sender
        {
            get;
            set;
        }
        public string SenderAdress
        {
            get;
            set;
        }
        public string Recipient
        {
            get;
            set;
        }
        public string RecipientAdress
        {
            get;
            set;
        }
        public int Regionid
        {
            get;
            set;
        }
        public bool Delivered
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string Postalcode
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }

        public Package()
        {
        }

        public Package(int packageid, string sender, string senderadress, string recipient, string recipientadress, int warehousenumber, string city, string country, string postalcode, string street)
        {
            PackageID = packageid;
            Sender = sender;
            SenderAdress = senderadress;
            Recipient = recipient;
            RecipientAdress = recipientadress;
            Regionid = warehousenumber;
            Delivered = false;
            City = city;
            Country = country;
            Postalcode = postalcode;
            Street = street;
        }
    }
}
