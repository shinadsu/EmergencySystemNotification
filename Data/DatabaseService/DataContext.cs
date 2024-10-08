﻿using EmergencySystemNotification.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystemNotification.Data.DatabaseService
{
	internal class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)  : base (options) 
		{ }

		public DbSet<User> users {  get; set; }
	}
}
