using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLite
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
