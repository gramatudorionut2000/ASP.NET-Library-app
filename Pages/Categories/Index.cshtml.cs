﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grama_Tudor_Ionut_Lab2.Data;
using Grama_Tudor_Ionut_Lab2.Models;
using Grama_Tudor_Ionut_Lab2.Models.ViewModels;
using System.Security.Policy;

namespace Grama_Tudor_Ionut_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Grama_Tudor_Ionut_Lab2.Data.Grama_Tudor_Ionut_Lab2Context _context;

        public IndexModel(Grama_Tudor_Ionut_Lab2.Data.Grama_Tudor_Ionut_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(i => i.Book)
            .ThenInclude(c => c.Author )
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                Category = await _context.Category.ToListAsync();
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;




            }


        }
    }
}
