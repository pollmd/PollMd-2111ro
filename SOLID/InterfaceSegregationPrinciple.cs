using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public interface ILead 
    {
        void CreateSubTask();
        void AssignTask();
    }

    public interface IProgrammer
    {
        void WorkOnTask();
    }
    public class TeamLead : ILead, IProgrammer
    {
        public void AssignTask()
        {
            //asigneaza task
        }

        public void CreateSubTask()
        {
            //creaza task
        }

        public void WorkOnTask()
        {
            //lucreaza pe task
        }
    }

    public class Manager : ILead
    {
        public void AssignTask()
        {
            //
        }

        public void CreateSubTask()
        {
            //
        }
    }
}
