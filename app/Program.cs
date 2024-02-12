using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace program{
    class Program{
        public static string randomString(){
            var numchars = "0123456789ABCDEFGHIJKLMNOPQRSRTUVWXYZ";
            var stringChars = new char[2];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++){
                stringChars[i] = numchars[random.Next(numchars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }
        static void Main(string[] args){
            int buffer_size;
            int matrix_width;
            int matrix_height;
            int sequence_count;
            string pattern = @"^[A-Z0-9]{2}\z";

            Console.Write("Masukkan ukuran buffer yang diinginkan : ");
            buffer_size = Convert.ToInt32(Console.ReadLine());

            string[] listchar = new string[buffer_size];

            Console.Write("Masukkan lebar dan tinggi matrix : ");
            string userInput = Console.ReadLine();
            string[] userProcessedInput = userInput.Split(" ");
            matrix_width = Convert.ToInt32(userProcessedInput[0]);
            matrix_height = Convert.ToInt32(userProcessedInput[1]);
            string[,] matrix = new string[matrix_width,matrix_height];

            int i = 0;
            int count = 1;
            while(i < matrix_width){
                Console.Write("Masukkan code pada baris ke-" + count + " : ");
                string userInputCode = Console.ReadLine();
                string[] userProcessedCode = userInputCode.Split(" ");
                string[] randomProcessedCode = new string[matrix_height];
                if(userProcessedCode.Length != matrix_height){
                    for(int j = 0; j < matrix_height; j++){
                        randomProcessedCode[j] = randomString();
                        matrix[i,j] = randomProcessedCode[j];
                    }
                }
                else{
                    for(int j = 0;j < matrix_height; j++){
                        if(!Regex.IsMatch(userProcessedCode[j],pattern)){
                            userProcessedCode[j] = randomString();
                        }
                        matrix[i,j] = userProcessedCode[j];
                    }
                }

                i++;
                count++;
            }
            Console.WriteLine("++++++++++++++++");
            for(int a = 0; a < matrix_width; a++){
                for(int j = 0; j < matrix_height; j++){
                    if(j == matrix_height - 1){
                        Console.WriteLine(matrix[a,j] + " ");
                    }
                    else{
                        Console.Write(matrix[a,j] + " ");
                    }
                }
            }
            Console.WriteLine("++++++++++++++++");
            Console.Write("Masukkan jumlah sequence yang diinginkan : ");
            sequence_count = Convert.ToInt32(Console.ReadLine());

            int[] sequence_reward = new int[sequence_count];
            List<List<string>> sequence_list = new List<List<string>>();
            Random rnd = new Random();
            for(int k = 0;k < sequence_count; k++){
                List<string> list_sequence_code = [matrix[0,0]];
                Console.Write("Masukkan code pada sequence ke-" + (k+1) + " : ");
                string userInputCode = Console.ReadLine();
                string[] userProcessedCode = userInputCode.Split(" ");
                string[] randomProcessedCode = new string[buffer_size];

                if(userProcessedCode.Length > buffer_size){
                    for(int j = 0; j < buffer_size - 1; j++){
                        randomProcessedCode[j] = randomString();
                        list_sequence_code.Add(randomProcessedCode[j]);
                        if(rnd.Next(0,20) < 10){
                            break;
                        }
                    }
                }
                else{
                    for(int j = 0;j < userProcessedCode.Length; j++){
                        if(Regex.IsMatch(userProcessedCode[j],pattern)){
                            list_sequence_code.Add(userProcessedCode[j]);
                        }
                        else{
                            userProcessedCode[j] = randomString();
                            list_sequence_code.Add(userProcessedCode[j]);
                        }
                        
                    }
                }
                for(int u = 0; u < list_sequence_code.Count;u++){
                    if(u == list_sequence_code.Count - 1){
                        Console.WriteLine(list_sequence_code[u] + " ");
                    }
                    else{
                        Console.Write(list_sequence_code[u] + " ");
                    }
                }
                sequence_list.Add(list_sequence_code);
                Console.Write("Masukkan nilai reward pada sequence ke-" + (k+1) + " : ");
                sequence_reward[k] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("++++++++++++++++");
            for(int u = 0; u < sequence_list.Count;u++){
                for(int g = 0 ; g < sequence_list[u].Count;g++){
                    if(g == sequence_list[u].Count - 1){
                        Console.WriteLine(sequence_list[u][g] + " ");
                    }
                    else{
                        Console.Write(sequence_list[u][g] + " ");
                    }
                }
            }
            Console.WriteLine("++++++++++++++++");
            int sum = 0;

            Stopwatch stopwatch = new Stopwatch();
            string[,] copy_matrix = new string[matrix_width,matrix_height];
            for(int u = 0; u < matrix_width; u++){
                for(int g = 0; g < matrix_height; g++){
                    copy_matrix[u,g] = matrix[u,g];
                }
            }
            listchar[0] = matrix[0,0];
            
            bool endsearch = false;
            int[] indexList = new int[sequence_count];

            while(!endsearch){
                int x = 0;
                int y = 0;
                int c = 0;
                int f = 0;
                bool not_found = false;
                
                while(!not_found){
                    if(f <= sequence_list.Count - 1){
                        if(c < sequence_list[f].Count - 1){
                            if(copy_matrix[x,y] == sequence_list[f][c]){
                                x = 0;
                                y = 0;
                                c++;
                            }
                            else{
                                if(y == matrix_height - 1){
                                    y = 0;
                                    x++;
                                }
                                else if(y < matrix_height - 1){
                                    y++;
                                }
                                else if(x == matrix_width - 1 && y == matrix_height - 1){
                                    x = 0;
                                    y = 0;
                                    c = 0;
                                    f++;
                                }
                            }
                        }
                        else if (c == sequence_list[f].Count - 1){
                            if(copy_matrix[x,y] == sequence_list[f][c-1]){
                                x = 0;
                                y = 0;
                                c = 0;
                                indexList[f] = f;
                                f++;
                            }
                            else{
                                if(y == matrix_height - 1){
                                    y = 0;
                                    x++;
                                }
                                else if(y < matrix_height - 1){
                                    y++;
                                }
                                else if(x == matrix_width - 1 && y == matrix_height - 1){
                                    x = 0;
                                    y = 0;
                                    c = 0;
                                    f++;
                                }
                            }
                        }
                        else{
                            x = 0;
                            y = 0;
                            c = 0;
                            f++;
                        }
                    }
                    else{
                        not_found = true;
                        endsearch = true;
                    }
                }
            }

            Console.WriteLine(indexList.Length);
            if(indexList.Length == 0){
                Console.WriteLine("Reward : " + sum);
            }
            else{
                if(indexList.Length == 1){
                    Console.WriteLine("Reward : " + sequence_reward[indexList[0]]);
                }
                else{
                    int buffer_needed_for_all = 0;
                    int q =0;
                    while(buffer_needed_for_all + sequence_list[indexList[q]].Count <= buffer_size && q < sequence_reward.Length){
                        sum += sequence_reward[q];
                        buffer_needed_for_all += sequence_list[indexList[q]].Count;
                        q++;
                    }
                    Console.WriteLine("Reward : " + sum);
                }
            }
        }
    }
}