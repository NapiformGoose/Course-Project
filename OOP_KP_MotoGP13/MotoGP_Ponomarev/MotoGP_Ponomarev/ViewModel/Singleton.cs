using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP_Ponomarev
{
    public class Singleton
    {
        private Singleton() { }

        private static IOperations repository;
        public static void Initialize(RepositoryType type)
        {
                switch (type)
                {
                    case RepositoryType.binary: repository = new BinaryRepository(); break;
                    case RepositoryType.text: repository = new TextRepository(); break;
                    case RepositoryType.memory: repository = new MemoryRepository(); break;
                    default: repository = repository ?? new MemoryRepository(); break;
                }
        }
        public IOperations Repository => repository;

        private static Singleton instance = new Singleton();



        public static Singleton Instance => instance ?? new Singleton();


    }
}
