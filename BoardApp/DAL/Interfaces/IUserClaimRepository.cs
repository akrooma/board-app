using System.Collections.Generic;
using Domain.Identity;

namespace DAL.Interfaces
{
    public interface IUserClaimIntRepository : IUserClaimRepository<UserClaimInt>
    {
    }

    public interface IUserClaimRepository : IUserClaimRepository<UserClaim>
    {
    }

    public interface IUserClaimRepository<TUserClaim> : IEFRepository<TUserClaim>
        where TUserClaim : class
    {
        List<TUserClaim> AllIncludeUser();
    }
}