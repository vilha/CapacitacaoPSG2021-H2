﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro26Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.EngineCategorias crud = new Engine.EngineCategorias();
            
            Console.WriteLine("Lista de Categorias:");

            foreach (var item in crud.Browse())
            {
                Console.WriteLine("ID: {0} - Decrição: {1}", item.CategoriadID, item.Descricao);
            }

            Console.ReadLine();
        }
    }
}
