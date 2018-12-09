using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP_Ponomarev
{
    public enum RepositoryType { text, binary, memory }
    public interface IOperations
    {
        void Add();
        void Reading();
        void Update();
        void Deletion(MotoGP obj);
    }
}
