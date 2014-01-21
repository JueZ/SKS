using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.DAL;
using SKS_PDS.Entities;

using log4net;
using log4net.Config;

using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace SKS_PDS.Services
{
    public class RegionImportService : IRegionImportService
    {
        private IRegionRepository _regionrepository;
        private readonly ILog logger;
        private GeoDataServiceAgent _geodataserviceagent;

        public RegionImportService(IRegionRepository regionrepository)
        {
            _regionrepository = regionrepository;

            _geodataserviceagent = new GeoDataServiceAgent();

            logger = LogManager.GetLogger(typeof(RegionImportService));
            logger.Debug("Initialisiert");
        }

        public void ImportRegion(RegionData regionData)
        {
            logger.Info("Entering ImportRegion");
            logger.Debug(regionData);
                

                Random rnd = new Random();

                foreach (RegionDataRegion regiondata in regionData.Region)
                {
                    double[] coords = _geodataserviceagent.EncodeCoordinates(regiondata.Address.PostalCode, regiondata.Address.City, regiondata.Address.Street);

                    Region region = new Region(rnd.Next(1, 1000000000), regiondata.Key, regiondata.DisplayName, regiondata.Address.PostalCode, regiondata.Address.City, coords[0], coords[1]);

                    _regionrepository.Add(region);
                }

            logger.Info("Exiting ImportRegion");
        }


        public void ImportRegion(string s)
        {
            logger.Info("Entering ImportRegion");
            logger.Debug(s);

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreWhitespace = true;
            readerSettings.IgnoreComments = true;
            readerSettings.ValidationType = ValidationType.Schema;
            readerSettings.Schemas.Add(null, @"XmlRegionImportSchema.xsd");
            readerSettings.ValidationEventHandler += ValidationCallback;

            XmlReader reader = XmlReader.Create(new StringReader(s), readerSettings);

            Region region = null;

            try 
            {
                while (reader.Read())
                {
                    string key = null;
                    string displayname = null;
                    string street = null;
                    string postalcode = null;
                    string city = null;

                    switch (reader.Name)
                    {
                        case "Region":
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "Key")
                                        key = reader.Value;
                                }
                            }
                            break;
                        case "DisplayName":
                            displayname = reader.ReadString();
                            break;
                        case "Street":
                            street = reader.ReadString();
                            break;
                        case "PostalCode":
                            postalcode = reader.ReadString();
                            break;
                        case "City":
                            city = reader.ReadString();
                            break;
                    }

                    double[] coords = _geodataserviceagent.EncodeCoordinates(postalcode, city, street);

                    region = new Region(0, key, displayname, postalcode, city, coords[0], coords[1]);

                    _regionrepository.Add(region);
                }
            }
            catch(Exception ex) 
            {
                logger.Error("Parsing failed", ex);
                throw new ServiceException("Parsing failed", ex);
            }

            reader.Close();

            logger.Info("Exiting ImportRegion");
        }

        void ValidationCallback(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }
    }
}
