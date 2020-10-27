using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailAid.Data;
using TrailAid.Models.AllTags;

namespace TrailAid.Services
{
    public class AllTagsService
    {
        public bool CreateAllTags()
        {
            var entity = new AllTags()
            {
                ListOfAllTags = "",

            };

            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.AllTags.Count() == 0)
                {
                    ctx.AllTags.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        public IEnumerable<AllTagsDetail> GetAllTags()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.AllTags.Select
                    (e => new AllTagsDetail
                    {
                        ListOfAllTags = e.ListOfAllTags,
                    }
                    );
                return query.ToArray();
            }

        }
        public string UpdateAllTags(AllTagsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.AllTags.Single();

                if (model.AddTags != null)
                {
                    if (entity.ListOfAllTags == null) entity.ListOfAllTags = "";
                    foreach (var tag in model.AddTags.Split(' '))
                    {
                        if (entity.ListOfAllTags.Contains(tag))
                        {
                            entity.ListOfAllTags = entity.ListOfAllTags;
                            return "Tag Already Exists";
                        }
                        entity.ListOfAllTags += $"{tag} ";
                    }
                }

                if (model.DeleteTags != null)
                {
                    foreach (var tag in model.DeleteTags.Split(' '))
                    {
                        int firstCount = entity.ListOfAllTags.Count();
                        string delete = entity.ListOfAllTags.Replace($"{tag}", "");
                        entity.ListOfAllTags = delete.Replace("  ", " ");
                        if (entity.ListOfAllTags.Count() < firstCount) { }
                        else return "Tag not found";
                    }
                }

                ctx.SaveChanges();
                return "Okay";
            }
        }
    }
}
