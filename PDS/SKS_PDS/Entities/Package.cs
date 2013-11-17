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
        private int _warehouseid;
        private bool _delivered;

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
        public int Warehouseid
        {
            get { return _warehouseid; }
            set { _warehouseid = value; }
        }
        public bool Delivered
        {
            get { return _delivered; }
            set { _delivered = value; }
        }

        public Package(int packageid, string sender, string senderadress, string recipient, string recipientadress, int warehousenumber)
        {
            this._packageid = packageid;
            this._sender = sender;
            this._senderadress = senderadress;
            this._recipient = recipient;
            this._recipientadress = recipientadress;
            this._warehouseid = warehousenumber;
            this._delivered = false;
        }
    }
}
