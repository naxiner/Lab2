using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class RecStudio
    {
        public string nameOfStudio { get; set; }
        public string adressOfStudio { get; set; }
        public int countOfWorkers { get; set; }
        public double trackCreationCost { get; set; }
        public int trackCreationTime { get; set; }
        public double oneWorkerSalary { get; set; }
        public double allWorkersSalary { get; set; }
        public int numberOfInstruments { get; set; }
        public int numbersOfRooms { get; set; }

        public RecStudio(string nameOfStudio)
        {
            this.nameOfStudio = nameOfStudio;
            adressOfStudio = "None";
            countOfWorkers = 0;
            trackCreationCost = 0;
            trackCreationTime = 0;
            oneWorkerSalary = 0;
            allWorkersSalary = 0;
            numberOfInstruments = 0;
            numbersOfRooms = 0;
        }

        public static RecStudio operator ++(RecStudio recStudio)
        {
            recStudio.numbersOfRooms++;
            recStudio.numberOfInstruments += 2;
            return recStudio;
        }

        public static RecStudio operator --(RecStudio recStudio)
        {
            recStudio.numbersOfRooms--;
            return recStudio;
        }


        public void AddRoom()
        {
            
            numbersOfRooms += 1;
        }

        public void RemoveRoom()
        {
            numbersOfRooms -= 1;
        }

        public void HireWorker()
        {
            countOfWorkers += 1;
        }

        public void FireWorker()
        {
            countOfWorkers -= 1;
        }
    }
}
