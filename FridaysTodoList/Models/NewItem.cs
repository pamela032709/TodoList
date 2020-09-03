using System;
using System.Collections.Generic;
using SQLite;


namespace FridaysTodoList.Models
{
    public class NewItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemNotes { get; set; }
        public string UserLocation { get; set; }
        public bool IsDone { get; set; }
        public DateTime Date { get; set; }
        
        
    
}
}
