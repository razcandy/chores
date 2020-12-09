using ChoresApp.Data.Models;
using ChoresApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChoresApp.Resources
{
	public static class GlobalData
    {
        // Constants ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static SessionModel userSession = new SessionModel();

        // Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static GlobalModel GlobalModel { get; set; } = new GlobalModel();

        public static SessionModel UserSession
		{
            get => userSession;
            private set
			{
                userSession = value;
                GlobalModel.AutoLogin = userSession.StayLoggedIn;
                GlobalModel.LastUsername = userSession.Username;
            }
        }

        public static bool IsUserLoggedIn { get; set; }

        // Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public static async Task SetUserSession(SessionModel _model)
		{
            if (_model == null) return;

            UserSession = _model;

            var connectionString = FileHelper.Directory + DatabaseKeys.Global;

            await DatabaseHelper.Upsert(GlobalModel, connectionString);
        }

    }
}
