using EmergencySystemNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystemNotification.Repository.IRepositories
{
	internal interface IUserRepository
	{
		Task<List<User>> GET();
		Task<User> GET(int id);
		Task DELETE(int id);
		Task POST(User user);
		Task PATCH(User user);	

	}
}
