using ChoresApp.Data;
using ChoresApp.Data.Models;
using ChoresApp.Resources;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoresApp.Helpers
{
	public static class DatabaseHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static async Task<List<T>> GetNFor<T>(int _limit, string _connectionString = null) where T : ModelBase
		{
			return await Task.Run(() =>
			{
				LiteDatabase db = null;

				try
				{
					if (_connectionString.IsNullOrEmpty())
					{
						_connectionString = FileHelper.UserDirectory + DatabaseKeys.Session;
					}

					db = new LiteDatabase(_connectionString);
					var col = db.GetCollection<T>();

					var res = col.Find(Query.All(), limit: _limit);

					return res == null ? new List<T>() : new List<T>(res);
				}
				catch (Exception e)
				{
					LogHelper.LogError(e.Message, typeof(T));
					return new List<T>();
				}
				finally
				{
					db?.Dispose();
				}
			});
		}

		public static async Task<bool> Upsert<T>(T _model, string _connectionString = null) where T : ModelBase
		{
			return await Task.Run(() =>
			{
				LiteDatabase db = null;

				try
				{
					if (_model == null) return false;

					if (_connectionString.IsNullOrEmpty())
					{
						_connectionString = FileHelper.UserDirectory + DatabaseKeys.Session;
					}

					db = new LiteDatabase(_connectionString);
					var col = db.GetCollection<T>();

					if (col == null) return false;

					col.Upsert(_model);

					return true;
				}
				catch (Exception e)
				{
					LogHelper.LogError(e.Message, typeof(T));
					return false;
				}
				finally
				{
					db?.Dispose();
				}
			});
		}

		public static async Task<List<T>> QueryOn<T>(Query _q, string _connectionString = null) where T : ModelBase
		{
			return await Task.Run(() =>
			{
				LiteDatabase db = null;

				try
				{
					if (_q == null) return new List<T>();

					if (_connectionString.IsNullOrEmpty())
					{
						_connectionString = FileHelper.UserDirectory + DatabaseKeys.Session;
					}

					db = new LiteDatabase(_connectionString);
					var col = db.GetCollection<T>();

					return new List<T>(col.Find(_q));
				}
				catch (Exception e)
				{
					LogHelper.LogError(e.Message, typeof(T));
					return new List<T>();
				}
				finally
				{
					db?.Dispose();
				}
			});
		}

		public static async Task<T> QueryOnPrimaryKey<T>(string _value, string _connectionString = null) where T : ModelBase
		{
			return await Task.Run(() =>
			{
				LiteDatabase db = null;

				try
				{
					if (_value.IsNullOrEmpty()) return null;

					if (_connectionString.IsNullOrEmpty())
					{
						_connectionString = FileHelper.UserDirectory + DatabaseKeys.Session;
					}

					db = new LiteDatabase(_connectionString);
					var col = db.GetCollection<T>();

					return col.FindById(_value);
				}
				catch (Exception e)
				{
					LogHelper.LogError(e.Message, typeof(T));
					return null;
				}
				finally
				{
					db?.Dispose();
				}
			});
		}
	}
}
