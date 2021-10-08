using System;
using backend.Database;

namespace backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.CheckConnection();
        }
    }
}