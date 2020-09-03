using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FridaysTodoList.Models;
using SQLite;

namespace FridaysTodoList.ServicesData
{
    public class DBConnection
    {
        public SQLiteConnection db { get; set; }
        public DBConnection()
        {
            string dbPath = Path.Combine(
                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "todo.db3");
            db = new SQLiteConnection(dbPath);
        }

        public void CreateTable<T>()
        {
            db.CreateTable<T>();

        }

        public void Insert<T>(T obj)
        {
            db.Insert(obj);

        }



    }


    public class TodoInfo
    {
        public static DBConnection Connection = new DBConnection();
        public TodoInfo()
        {


            Connection.CreateTable<NewItem>();
            Connection.CreateTable<PendingItems>();

        }

        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemNotes { get; set; }
        public bool IsDone { get; set; }

        public void Add(int id, string itemname, string itemnotes, bool isdone)
        {

            Connection.Insert<NewItem>(new NewItem() { ID = id, ItemName = itemname, ItemNotes = itemnotes ?? "User didnt add any notes", IsDone = false,  });
            Console.WriteLine(itemname + "Added to list ");

        }

       

        int LstItem;
       
        public Task<int> SaveItems(NewItem item)
        {
            if (item.ID != 0)
            {
                LstItem =  Connection.db.Update(item);
            }
            else
            {
                LstItem = Connection.db.Insert(item);
            }

            return Task.FromResult(LstItem);

        }

        public Task<int> Update(NewItem item)
        {

            if (item.ID != 0)
            {
                LstItem = Connection.db.Update(item);
            }
            else
            {
                LstItem = Connection.db.Insert(item);
            }
            return Task.FromResult(LstItem);

        }



        List<NewItem> ev = new List<NewItem>();

        public Task<List<NewItem>> GetAllNotification()
        {
            ev = Connection.db.Table<NewItem>().ToList();
            return Task.FromResult(ev);
        }

        public List<NewItem> GetItems()
        {
            Console.WriteLine("Getting data");
            List<NewItem> table = Connection.db.Table<NewItem>().ToList();
            return table;
        }

        public Task<NewItem> GetSelectedItem(int id)
        {
            var ar = Connection.db.Table<NewItem>().Where(i => i.ID == id).FirstOrDefault();
            return Task.FromResult(ar);
            
        }
        //public Task<NewItem> AddAdditionalItems(int id)
        //{
        //    var ar = Connection.db.Table<NewItem>().Where(i => i.ID == id).FirstOrDefault();
        //    var add=  Connection.db.Insert(ar);
        //    return Task.FromResult(add);

        //}

        public Task<NewItem> UpdateSelectedName(NewItem item)
        {
            //var list = loadList; loadList.Where(p => p.EmpNo == obj.EmpNo).Update();  
            var ar = Connection.db.Table<NewItem>().Where(i => i.ItemName == item.ItemName).FirstOrDefault();

            var update= Connection.db.Update(ar);

            return Task.FromResult(ar);

        }

        public Task<int> DeleteItem(NewItem item)
        {
            NewItem SelectedItem;
            SelectedItem = Connection.db.Table<NewItem>().FirstOrDefault(p => p.ID == item.ID);

            var ar = Connection.db.Delete<NewItem>(SelectedItem.ID);
            return Task.FromResult(ar);
            
        }
        public void Delete(int selectedId)
        {
            int pt;
            NewItem SelectedItem;
            try
            {
                SelectedItem = Connection.db.Table<NewItem>().FirstOrDefault(p => p.ID == selectedId);
                Connection.db.Delete<NewItem>(SelectedItem.ID);
                pt = SelectedItem.ID;
                Console.WriteLine(SelectedItem.ID + "Deleted for favorites ");

            }
            catch (Exception e)
            {
               // Console.WriteLine("Couldnt be remove at" + Id + "ex" + e.Message);
            }

            

        }

        public Task<List<NewItem>> GetItemsNotCompleted()
        {
            var pr= Connection.db.Query<NewItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            return Task.FromResult(pr);
        }


        public bool Exist(int id)
        {
            Console.WriteLine("Reading data");
            var table = Connection.db.Table<NewItem>().FirstOrDefault(p => p.ID == id);
            return table != null;
        }
    }


}
