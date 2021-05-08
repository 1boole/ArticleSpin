using Business.Abstract;
using Business.Utilities.FileHelper;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business.Concrete
{
    public class VariableManeger : IVariableService
    {


        public int SearchInXml(string[] SearchValue, string[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                for (int a = 0; a < SearchValue.Length; a++)
                {

                    if (SearchValue[a] == array[i])
                    {
                        return i;

                    }
                }
            }
            return -1;
        }

        public string VariablesSpiner(string inputText, DataGridView data)
        {
            XlsxFileReader xlsxFileReader = new XlsxFileReader();
            //var punctuation = inputText.Where(Char.IsPunctuation).Distinct().ToArray();
            //string[] words = inputText.Split().Select(x => x.Trim(punctuation)).ToArray();

            List<string> words = new List<string>(inputText.Split(" ").ToList());
            List<string> outputWords = new List<string>();

            //for (int i = 0; i <= words.Count; i++)
            //{
            //    var result = xlsxFileReader.Search(data, words[i]);
            //    outputWords.Add(result);
            //    i++;

            //}

            foreach (var item in words)
            {
                var result = xlsxFileReader.Search(data, item);
                outputWords.Add(result);
            }



            //List<string> words = new List<string> (inputText.Split(" ").ToList());
            //for (int i = 0; i <words.Count; i++)
            //{
            //    var result = xlsxFileReader.Search(data, words[i]);
            //    words[i] = result;
            //    i++;
            //}


            string outpuText = string.Join(" ", outputWords);
            return outpuText;
        }



    }
}
