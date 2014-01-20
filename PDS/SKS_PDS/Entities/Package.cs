using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKS_PDS.Entities
{
    public class Package
    {
        private int _packageid;
        private string _sender;
        private string _senderadress;
        private string _recipient;
        private string _recipientadress;
        private int _regionid;
        private bool _delivered;
        private string _city;
        private string _country;
        private string _postalcode;
        private string _street;

        public int PackageID
        {
            get { return _packageid; }
        }
        public string Sender
        {
            get { return _sender; }
        }
        public string SenderAdress
        {
            get { return _senderadress; }
        }
        public string Recipient
        {
            get { return _recipient; }
        }
        public string RecipientAdress
        {
            get { return _recipientadress; }
        }
        public int Regionid
        {
            get { return _regionid; }
            set { _regionid = value; }
        }
        public bool Delivered
        {
            get { return _delivered; }
            set { _delivered = value; }
        }
        public string City
        {
            get { return _city; }
        }
        public string Country
        {
            get { return _country; }
        }
        public string Postalcode
        {
            get { return _postalcode; }
        }
        public string Street
        {
            get { return _street; }
        }

        public Package(int packageid, string sender, string senderadress, string recipient, string recipientadress, int warehousenumber, string city, string country, string postalcode, string street)
        {
            this._packageid = packageid;
            this._sender = sender;
            this._senderadress = senderadress;
            this._recipient = recipient;
            this._recipientadress = recipientadress;
            this._regionid = warehousenumber;
            this._delivered = false;
            this._city = city;
            this._country = country;
            this._postalcode = postalcode;
            this._street = street;
        }
    }
}
