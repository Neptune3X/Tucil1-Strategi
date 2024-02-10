using System;
using System.IO;

namespace program{
    class program{
        private static void main(){
            string[] listChar;
            int bufferCount;
            int matrix_X;
            int matrix_Y;
            int sequenceCount;

            Console.Write("Masukkan Jumlah Buffer yang diinginkan : ");
            bufferCount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Masukkan Ukuran Matriks yang diinginkan : ");
            string userInput = Console.ReadLine();

            var splittedItems = userInput.Split(' ');
            if(splittedItems.Length != 2){
                
            }
        }
    }
}