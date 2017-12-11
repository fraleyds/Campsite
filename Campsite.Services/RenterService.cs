using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Data;
using Campsite.Models.Renter;

namespace Campsite.Services
{
    public class RenterService : IRenterService
    {
        private readonly Guid _userId;

        public RenterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRenter(RenterCreate model)
        {
            var entity =
                new RenterEntity()
                {
                    UserId = _userId,
                    Contact = model.Contact
                };
            using (var ctx = new CampsiteDbContext())
            {
                ctx.Renter.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RenterListItem> GetRenters()
        {
            using (var ctx = new CampsiteDbContext())
            {
                var query =
                    ctx
                        .Renter
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new RenterListItem
                                {
                                    RenterId = e.RenterId,
                                    Contact = e.Contact,
                                    RenterRating = e.RenterRating,
                                    IsRenting = e.IsRenting
                                }
                        );
                return query.ToArray();
            }
        }

        public RenterDetail GetRenterById(int renterId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Renter
                        .Single(e => e.RenterId == renterId && e.UserId == _userId);

                return
                    new RenterDetail
                    {
                        RenterId = entity.RenterId,
                        Contact = entity.Contact,
                        RenterRating = entity.RenterRating,
                        IsRenting = entity.IsRenting
                    };
            }
        }

        public bool UpdateRenter(RenterEdit model)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Renter
                        .Single(e => e.RenterId == model.RenterId && e.UserId == _userId);

                entity.Contact = model.Contact;
                entity.RenterRating = model.RenterRating;
                entity.IsRenting = model.IsRenting;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRenter(int renterId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Renter
                        .Single(e => e.RenterId == renterId && e.UserId == _userId);

                ctx.Renter.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
