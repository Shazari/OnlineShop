using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace Data.Base
{
	public abstract class UnitOfWork :IUnitOfWork
	{
	

		public UnitOfWork(Options options) : base()
		{
			Options = options;
			

		}
		

		protected Options Options { get; set; }
		
		private ParsMarketDbContext _databaseContext;
		
		internal ParsMarketDbContext DatabaseContext
		{
			get
			{
				if (_databaseContext == null)
				{
					var optionsBuilder =
						new DbContextOptionsBuilder<ParsMarketDbContext>();

					switch (Options.Provider)
					{
						case Provider.SqlServer:
							{
								optionsBuilder.UseSqlServer
									(connectionString: Options.ConnectionString);

								break;
							}

						case Provider.MySql:
							{
							
								break;
							}

						case Provider.Oracle:
							{
								
								break;
							}

						case Provider.PostgreSQL:
							{
								
								break;
							}

						

						default:
							{
								break;
							}
					}

					_databaseContext =
						new ParsMarketDbContext(options: optionsBuilder.Options);
				}

				return _databaseContext;
			}
		}


        Repository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(databaseContxt: DatabaseContext);
        }

        public virtual void Save()
		{
			DatabaseContext.SaveChanges();
		}

        public virtual async System.Threading.Tasks.Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }

        // **********
        /// <summary>
        /// To detect redundant calls
        /// </summary>
        public bool IsDisposed { get; protected set; }

        //public IMenuRepository MenuRepository => throw new NotImplementedException();

        // **********

        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers.
        /// </summary>
        public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}

		/// <summary>
		/// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				// TODO: dispose managed state (managed objects).

				if (_databaseContext != null)
				{
					_databaseContext.Dispose();
					_databaseContext = null;
				}
			}

			// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
			// TODO: set large fields to null.

			IsDisposed = true;
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
	}
}
