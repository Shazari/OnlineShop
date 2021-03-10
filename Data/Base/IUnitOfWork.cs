﻿using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Data.Base
{
	public interface IUnitOfWork : System.IDisposable
	{
		bool IsDisposed { get; }

		void Save();

		System.Threading.Tasks.Task SaveAsync();

		Repository<T> GetRepository<T>() where T : BaseEntity;
	}
}