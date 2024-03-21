﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    internal class Elevator
    {
        private Dictionary<string, bool> D_elevator = new Dictionary<string, bool>();
        private Dictionary<string, int> Floor = new Dictionary<string, int>();
        private int Head; // vị trí thang máy hiện tại
        private bool Directions; //true = up, false = down
        private List<string> Up;
        private List<string> Down;
        private Queue<string> Input;
        public bool Use;
        private Elevator()
        {
            Input = new Queue<string>();
            Up = new List<string>();
            Down = new List<string>();
            Directions = true;
            Head = 3;
            Use = true;

            D_elevator.Add("1", false);
            D_elevator.Add("2D", false);
            D_elevator.Add("3D", false);
            D_elevator.Add("4D", false);
            D_elevator.Add("5D", false);
            D_elevator.Add("2U", true);
            D_elevator.Add("3U", true);
            D_elevator.Add("4U", true);
            D_elevator.Add("5U", true);
            D_elevator.Add("6", true);

            Floor.Add("1", 1);
            Floor.Add("2D", 2);
            Floor.Add("3D", 3);
            Floor.Add("4D", 4);
            Floor.Add("5D", 5);
            Floor.Add("2U", 2);
            Floor.Add("3U", 3);
            Floor.Add("4U", 4);
            Floor.Add("5U", 5);
            Floor.Add("6", 6);
        }
        public void Insert(string buttom)
        {
            Input.Enqueue(buttom);
            InsertE(buttom);
        }
        private void InsertE(string buttom)
        {
            while(Input.Count > 0)
            {
                string check = Input.Dequeue();
                if (D_elevator[check])
                {
                    InsertU(check);
                }
                else
                {
                    InsertD(check);
                }
            }
        }
        private void InsertU(string buttom)
        {
            Up.Add(buttom);
            Up = InsertionSort(Up);
        }
        private void InsertD(string buttom)
        {
            Down.Add(buttom);
            Down = InsertionSort(Down);
        }
        private List<string> InsertionSort(List<string> a)
        {
            if (a.Count == 0) { return null; }
            for (int i = 1; i < a.Count; i++)
            {
                int key = Floor[a[i]];
                string temp = a[i];
                int j = i - 1;
              
                while (j >= 0 && Floor[a[j]] > key)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = temp;
            }
            return a;
        }
        public void Use_Elevator()
        {
            while (Use)
            {
                ScanE();
            }
        }
        private void ScanE()
        {
            if (Directions)
            {
                while (Up.Count > 0)
                {
                    Run(Floor[Up[0]]);
                    Up.RemoveAt(0);
                }
            }
            else
            {
                while (Down.Count > 0)
                {
                    Run(Floor[Down[Down.Count - 1]]);
                    Down.RemoveAt(Down.Count - 1);
                }
            }
        }
        private void Run(int floor)
        {
            if(Head == 1 || Head == 6)
            {
                Directions = !Directions;
            }

            Console.WriteLine(floor);
        }
    }
}