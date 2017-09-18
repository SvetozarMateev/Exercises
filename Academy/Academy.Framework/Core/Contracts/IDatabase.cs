
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Framework.Core.Contracts
{
    public interface IDatabase
    {
        IList<ISeason> Seasons { get; }
        IList<IStudent> Students { get; }
        IList<ITrainer> Trainers { get; }
    }
}
