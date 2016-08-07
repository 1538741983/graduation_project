using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JudgeEngine
{
    public class Comparer
    {
        private string standardOutput;



        public Comparer(string standardOutputFilePath)
        {
            using (StreamReader streamReader = new StreamReader(standardOutputFilePath, Encoding.UTF8))
            {
                standardOutput = streamReader.ReadToEnd();
            }
        }

        public string Start(string output)
        {
            if (output == standardOutput)
                return "Accepted";


            //int lenght = output.Length < standardOutput.Length ? output.Length : standardOutput.Length;


            //for (int i = 0; i < lenght; i++)
            //{
            //    if (standardOutput[i] != output[i])
            //    {
            //        if(standardOutput[i]==' ')
            //    }
            //}


            return "WrongAnswer";
            if (output == standardOutput)
                return "AC";
            return "WA";
        }
    }
}
