﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eHairdresserSalon_API.Util
{
    public class ExceptionHandler
    {
        public static string HandleException(EntityException ex)
        {
            SqlException error = ex.InnerException as SqlException;

            switch (error.Number)
            {
                case 2601:
                    return GetConstraintExceptionMessage(error);
                default:
                    return error.Message + " (" + error.Number + ")";
            }
        }

        private static string GetConstraintExceptionMessage(SqlException error)
        {
            /*
             * SqlException: Cannot insert duplicate key row in object 'dbo.Klijenti' 
             * with unique index 'CS_KorisnickoIme'. The duplicate key value is (aida96).
             */
            string newMessage = error.Message;

            int startIndex = newMessage.IndexOf("'");
            int endIndex = newMessage.IndexOf("'", startIndex + 1);

            if(startIndex>0 && endIndex>0)
            {
                string constraintName = newMessage.Substring(startIndex + 1, endIndex - startIndex - 1);

                if (constraintName == "CS_KorisnickoIme")
                    newMessage = "username_con";
                else if (constraintName == "CS_Email")
                    newMessage = "email_con";
            }
            return newMessage;
        }
    }
}