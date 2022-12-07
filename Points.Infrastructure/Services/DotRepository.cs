using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Points.Application.Interfaces;
using Points.Domain.Entities;
using Points.Domain.ViewModels;
using Points.Infrastructure.Persistance;

namespace Points.Infrastructure.Services
{
    public class DotRepository : IDotRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DotRepository(AppDbContext context, 
                            IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<Dot> CreateDot(DotViewModel dotVM)
        {
            var dot = _mapper.Map<Dot>(dotVM);

            await _context.Dots.AddAsync(dot);
            await SaveDotAsync();

            return dot;
        }

        public async Task<IEnumerable<Dot>> GetAllDots()
        {
           

            if(_context.Dots.Count() == 0)
            {
                CommentViewModel commentViewModel = new CommentViewModel()
                {
                    BackgroundColor = "Yellow",
                    Text = "Comment 1"
                };

                DotViewModel dotViewModel = new DotViewModel()
                {
                    Color = "Red",
                    PositionX = 200,
                    PositionY = 200,
                    Radius = 25,
                    Comments = new List<CommentViewModel>() { commentViewModel}    
                };
                await CreateDot(dotViewModel);

                CommentViewModel commentViewModel2 = new CommentViewModel()
                {
                    BackgroundColor = "White",
                    Text = "Comment 2"
                };

                CommentViewModel commentViewModel3 = new CommentViewModel()
                {
                    BackgroundColor = "White",
                    Text = "Comment 3"
                };


                DotViewModel dotViewModel2 = new DotViewModel()
                {
                    Color = "Grey",
                    PositionX = 250,
                    PositionY = 300,
                    Radius = 25,
                    Comments = new List<CommentViewModel>() { commentViewModel2,commentViewModel3 }
                };
                await CreateDot(dotViewModel2);
            }
            var dots = await _context.Dots
                                   .Include(d => d.Comments)
                                   .ToListAsync();
            return dots;
        }

        public async Task<bool> RemoveDot(int dotId)
        {
            var dot = await _context.Dots.SingleOrDefaultAsync(d => d.Id == dotId);
            _context.Dots.Remove(dot);
            return await SaveDotAsync();
        }

        public async Task<bool> SaveDotAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}