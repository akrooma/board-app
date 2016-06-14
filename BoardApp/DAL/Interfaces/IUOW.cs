﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Identity;

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
        
        IEFRepository<RouteInEvent> RouteInEvents { get; }
        IEFRepository<TransportItemType> TransportItemTypes { get; }
        IEFRepository<TransportItemTypeAttribute> TransportItemTypeAttributes { get; }
        IEFRepository<TransportItemTypeAttributeValue> TransportItemTypeAttributeValues { get; }
		IEFRepository<TransportItemAndAttributeValue> TransportItemAndAttributeValues { get; }

			//Customs repos, manually implemented. Repos with custom methos.
		IRouteCommentRepository RouteComments { get; }
        IRouteAndCharacteristicRepository RouteAndCharacteristics { get; }
		ITransportItemRepository TransportItems { get; }

		IArticleRepository Articles { get; }
        IMultiLangStringRepository MultiLangStrings { get; }
        ITranslationRepository Translations { get; }

        // Identity
        IUserIntRepository UsersInt { get; }
        IUserRoleIntRepository UserRolesInt { get; }
        IRoleIntRepository RolesInt { get; }
        IUserClaimIntRepository UserClaimsInt { get; }
        IUserLoginIntRepository UserLoginsInt { get; }
    }
}
