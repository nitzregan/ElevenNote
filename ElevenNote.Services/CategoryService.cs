using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        //private readonly Guid _userId;

        //public CategoryService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    CategoryTitle = model.CategoryTitle,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CategoryID = e.CategoryID,
                                    CategoryTitle = e.CategoryTitle
                                }
                        );

                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryID == id/* && e.OwnerId == _userId*/);
                return
                    new CategoryDetail
                    {
                        CategoryID = entity.CategoryID,
                        CategoryTitle = entity.CategoryTitle,
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryID == model.CategoryID /*&& e.OwnerId == _userId*/);

                entity.CategoryTitle = model.CategoryTitle;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryID == categoryID/* && e.OwnerId == _userId*/);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
