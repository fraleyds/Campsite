using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campsite.Contracts;
using Campsite.Data;
using Campsite.Models.Owner;

namespace Campsite.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly Guid _userId;

        public OwnerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOwner(OwnerCreate model)
        {
            var entity =
                new OwnerEntity()
                {
                    UserId = _userId,
                    Contact = model.Contact
                };
            using (var ctx = new CampsiteDbContext())
            {
                ctx.Owner.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OwnerListItem> GetOwners()
        {
            using (var ctx = new CampsiteDbContext())
            {
                var query =
                    ctx
                        .Owner
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new OwnerListItem
                                {
                                    OwnerId = e.OwnerId,
                                    Contact = e.Contact,
                                    OwnerRating = e.OwnerRating
                                }
                        );
                return query.ToArray();
            }
        }

        public OwnerDetail GetOwnerById(int ownerId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Owner
                        .Single(e => e.OwnerId == ownerId && e.UserId == _userId);

                return
                    new OwnerDetail
                    {
                        OwnerId = entity.OwnerId,
                        Contact = entity.Contact,
                        OwnerRating = entity.OwnerRating
                    };
            }
        }

        public bool UpdateOwner(OwnerEdit model)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Owner
                        .Single(e => e.OwnerId == model.OwnerId && e.UserId == _userId);

                entity.Contact = model.Contact;
                entity.OwnerRating = model.OwnerRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOwner(int ownerId)
        {
            using (var ctx = new CampsiteDbContext())
            {
                var entity =
                    ctx
                        .Owner
                        .Single(e => e.OwnerId == ownerId && e.UserId == _userId);

                ctx.Owner.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
