using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;


namespace Presentation.Model
{
    public class MTask : NotifiableModelObject
    {
        private int id;
        private string title;
        private string description;
        private DateTime creationTime;
        private DateTime dueDate;
        private String email;
        private int colID;


        public MTask(BackendController controller, int id, string title, string description, DateTime creationTime, DateTime dueDate, String email, int colID) : base(controller)
        {
            this.colID = colID;
            this.id = id;
            this.title = title;
            this.description = description;
            this.creationTime = creationTime;
            this.dueDate = dueDate;
            this.email = email;
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
            }
        }
        public string Description
        {
            get => description; set
            {
                description = value;
            }
        }
        public DateTime CreationTime
        {
            get => creationTime;
        }
        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                dueDate = value;
            }
        }
        public String Email { get => email; }
        public int Id
        {
            get => id;           
        }
        public Tuple<String[], String []> EditTask()
        {
            String[] Msg = { TitleUpdate().Item1, DescriptionUpdate().Item1, DueDateUpdate().Item1 };
            String[] editErr = { TitleUpdate().Item2, DescriptionUpdate().Item2, DueDateUpdate().Item2 };
            return new Tuple<String[], String[]>(Msg, editErr);
        }


        public Tuple<String, String> DueDateUpdate()
        {
            String errMsg = "";
            String  indic = "";
            try
            {
                Controller.UpdateTaskDueDate(email, colID, id, dueDate);
            }
            catch (Exception e)
            {
                errMsg = "Could not update task's due date" + e.Message;
                indic = "DueDate";
            }
            return new Tuple<String, String>(errMsg, indic);
        }


        public Tuple<String, String> TitleUpdate()
        {
            String errMsg = "";
            String indic = "";
            try
            {
                Controller.UpdateTaskTitle(email, colID, id, title);
            }
            catch (Exception e)
            {
                errMsg = "Could not update task's title" + e.Message;
                indic = "Title";
            }
            return new Tuple<String, String>(errMsg, indic);
        }


        public Tuple<String, String> DescriptionUpdate()
        {
            String errMsg = "";
            String indic = "";
            try
            {
                Controller.UpdateTaskDescription(email, colID, id, description);
            }
            catch (Exception e)
            {
                errMsg = "Could not update task's description" + e.Message;
                indic = "Description";
            }
            return new Tuple<String, String>(errMsg, indic); 
        }

        public int ColID { get => colID;}
    }
}
