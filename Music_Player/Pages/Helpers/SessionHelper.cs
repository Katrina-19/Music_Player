using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Music_Player.Models;

namespace Music_Player.Pages.Helpers
{
    public enum SessionKey
    {
        LIST,
        RETURN_URL
    }

    public static class SessionHelper
    {

        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }

        public static PlayList GetList(HttpSessionState session)
        {
            PlayList myList = Get<PlayList>(session, SessionKey.LIST);
            if (myList == null)
            {
                myList = new PlayList();
                Set(session, SessionKey.LIST, myList);
            }
            return myList;
        }
    }
}