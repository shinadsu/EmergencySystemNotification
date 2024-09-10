using EmergencySystemNotification.Data.DatabaseService;
using EmergencySystemNotification.Models;
using EmergencySystemNotification.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystemNotification.Repository
{
	internal class UserRepository : IUserRepository
	{	
		private DataContext _dataContext;
		public UserRepository(DataContext dataContext) 
		{
			_dataContext = dataContext;
		}

		public Task DELETE(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<User>> GET()
		{
			return await _dataContext.users.AsNoTracking().ToListAsync();
		}

		public Task<User> GET(int id)
		{
			throw new NotImplementedException();
		}

		public Task PATCH(User user)
		{
			throw new NotImplementedException();
		}

		public Task POST(User user)
		{
			throw new NotImplementedException();
		}
	}
}
