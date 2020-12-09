using ChoresApp.Data;
using ChoresApp.Data.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoresApp.Helpers
{
	public static class ChDatabaseHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		public static async Task<bool> Upsert<T>(T _model) where T : ModelBase
		{
			return await Task.Run(() =>
			{
				try
				{
					if (_model == null) return false;

					var db = new LiteDatabase(FileHelper.UserDirectory + DatabaseKeys.Session);
					//var db = new LiteDatabase("C:\\Users\\razca\\Documents\\rawr.db");
					//C:\Users\razca\Documents\

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
			});
		}

	}
}
