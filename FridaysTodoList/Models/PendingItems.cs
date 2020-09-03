using System;
using SQLite;
using Xamarin.Forms;

namespace FridaysTodoList.Models
{
    public class PendingItems 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
    }
}

