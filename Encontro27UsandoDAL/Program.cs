using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro27UsandoDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            AtacadoModel crud = new AtacadoModel();

            Console.WriteLine("Lista de Microregiões:");

            foreach (var item in crud.Microregiaos.ToList())
            {
                Console.WriteLine("ID: {0} - Decrição: {1}", item.MicroregiaoID, item.Descricao);
            }

            Console.ReadLine();
        }
    }
}
