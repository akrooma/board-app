﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IUOW
    {
        //save pending changes to the data store
        void Commit();

        //get repository for type
        T GetRepository<T>() where T : class;

        //Standard repos, autogenerated. Repos without custom methods.
        IEFRepository<Event> Events { get; }
        IEFRepository<MapPoint> MapPoints { get; }
        IEFRepository<Route> Routes { get; }
        IEFRepository<RouteCharacteristic> RouteCharacteristics { get; }
        IEFRepository<RouteAndCharacteristic> RouteAndCharacteristics { get; }
        IEFRepository<RouteComment> RouteComments { get; }
        IEFRepository<RouteInEvent> RouteInEvents { get; }
        IEFRepository<TransportItem> TransportItems { get; }
        IEFRepository<TransportItemType> TransportItemTypes { get; }
        IEFRepository<TransportItemTypeAttribute> TransportItemTypeAttributes { get; }
        IEFRepository<TransportItemTypeAttributeValue> TransportItemTypeAttributeValues { get; }
        //IEFRepository<Contact> Contacts { get; }
        //IEFRepository<ContactType> ContactTypes { get; }

        //Customs repos, manually implemented. Repos with custom methos.
        //IPersonRepository Persons { get; }
    }
}
