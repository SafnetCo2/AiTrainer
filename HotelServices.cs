using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelChatbotBackend
{
    public class HotelStaffService
    {
        private readonly HotelDbContext _dbContext;

        public HotelStaffService(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Fetch all hotel staff
        public async Task<List<HotelStaff>> GetHotelStaffAsync()
        {
            return await _dbContext.HotelStaffs.ToListAsync();
        }
    }
}
