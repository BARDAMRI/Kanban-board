using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Model;
using System.Windows;

namespace Presentation.ViewModel
{
    class TaskViewModel : NotifiableObject
    {
        private MTask taskmod;
        private bool editable;
        private string editState;
        private MTask rollback;



        public TaskViewModel(BackendController controller ,MTask task)
        {
            taskmod = task;
            rollback = new MTask(controller, task.Id, task.Title, task.Description, task.CreationTime, task.DueDate, task.Email, task.ColID);
        }




        public BackendController Controller { get; private set; }

        public string Title
        {
            get => taskmod.Title;
            set
            {
                taskmod.Title = value;
                RaisePropertyChanged("Title");
            }
        }
        public string Description
        {
            get => taskmod.Description;
            set
            {
                taskmod.Description = value;
                RaisePropertyChanged("Description");
            }
        }
        public DateTime CreationTime { get => taskmod.CreationTime; }
        public DateTime DueDate
        {
            get => taskmod.DueDate;
            set
            {
                taskmod.DueDate = value;
                RaisePropertyChanged("DueDate");
            }
        }


        public string EditState
        {
            get => editState;
            set
            {
                editState = value;
                RaisePropertyChanged("EditState");
            }
        }

        public bool Editable {
            get => editable;
            set {
                editable = value;
                RaisePropertyChanged("Editable");
            }
        }

        public void EditButton_Click()
        {
            Editable = !Editable;
            if (Editable)
            {
                EditState = "Done";
            }
            else
            {
                Tuple<String[], String[]> editResult = taskmod.EditTask();

                String[] msgArr = editResult.Item1;
                String Msg = "";
                for (int i = 0; i < msgArr.Length; i++)
                {
                    if (Msg != "")
                    {
                        Msg += msgArr[i] + "\r\n";
                    }
                }
                String[] errs = editResult.Item2;
                if (Msg != "")
                {
                    MessageBox.Show("Could not execute Task Edit properly" + Msg);
                    for(int i = 0; i <  errs.Length; i++)
                    {
                        if(errs[i] != "")
                        {
                            errCheck(errs[i]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Task Edit has been completed");
                }
                rollback.Description = Description;
                rollback.Title = Title;
                rollback.DueDate = DueDate;
                EditState = "Edit Task";
            }
        }

        public void errCheck(String err)
        {
            if(err == "DueDate")
            {
                DueDate = rollback.DueDate;
                return;
            }
            if (err == "Title")
            {
                Title = rollback.Title;
                return;
            }
            if(err == "Description"){
                Description = rollback.Description;
                return;
            }
        } 
    }
}

