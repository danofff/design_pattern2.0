using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace command
{
    class Program
    {
        public interface ICommand
        {
            void Execute();
        }

        public class Database
        {
            public void Insert()
            {
                Console.WriteLine("Inserting");
            }
            public void Update()
            {
                Console.WriteLine("Updating");
            }
            public void Select()
            {
                Console.WriteLine("Selecting");
            }
            public void Delete()
            {
                Console.WriteLine("Deleting");
            }
        }

        public class DeleteCommand : ICommand
        {
            private Database database;

            public DeleteCommand(Database db)
            {
                database = db;
            }

            public void Execute()
            {
                database.Delete();
            }
        }

        public class UpdateCommand : ICommand
        {
            private Database database;

            public UpdateCommand(Database db)
            {
                database = db;
            }

            public void Execute()
            {
                database.Update();
            }
        }

        public class InsertCommand : ICommand
        {
            private Database database;

            public InsertCommand(Database db)
            {
                database = db;
            }

            public void Execute()
            {
                database.Insert();
            }
        }

        public class SelectCommand : ICommand
        {
            private Database database;

            public SelectCommand(Database db)
            {
                database = db;
            }

            public void Execute()
            {
                database.Select();
            }
        }

        public class Developer
        {
            private ICommand Insert;
            private ICommand Select;
            private ICommand Update;
            private ICommand Delete;

            public Developer(ICommand insert, ICommand select, ICommand update, ICommand delete)
            {
                Insert = insert;
                Select = select;
                Update = update;
                Delete = delete;
            }

            public void InsertRecord()
            {            
                Insert.Execute();
            }
            public void SelectRecord()
            {
                Select.Execute();
            }
            public void UpdateRecord()
            {
                Update.Execute();
            }
            public void DeleteRecord()
            {
                Delete.Execute();
            }
        }

        public interface ITransaction
        {
            void Commit();
            void RollBack();
        }

        public class Trasaction : ITransaction
        {


            private Developer dev;
            public Trasaction(Developer d)
            {
                dev = d;
            }

            public void Commit()
            {
                try
                {
                    dev.InsertRecord();
                    dev.SelectRecord();
                    dev.UpdateRecord();
                    dev.DeleteRecord();
                }
                catch (Exception )
                {
                    RollBack();
                }
             
            }

            public void RollBack()
            {
                Console.WriteLine("Transaction rollback");
            }
        }

        static void Main(string[] args)
        {

            Database db = new Database();

            Developer dev = new Developer(new InsertCommand(db), new SelectCommand(db), new UpdateCommand(db), new DeleteCommand(db));
            Trasaction trans = new Trasaction(dev);

            trans.Commit();

            Console.ReadKey();

        }

    }
}
