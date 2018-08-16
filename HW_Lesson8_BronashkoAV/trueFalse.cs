using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace HW_Lesson8_BronashkoAV
{
    class TrueFalse
    {
        private string fileName;
        List<Question> list;

        public string FileName { get => fileName; set => fileName = value; }

        public TrueFalse()
        {
        }

        public TrueFalse(string fileName)
        {
            this.FileName = fileName;
            list = new List<Question>();
        }

        public void LoadFromTxt(string fileNameTxt)
        {
            string[] lines = File.ReadAllLines(fileNameTxt, System.Text.Encoding.Default);
            foreach (var line in lines)
            {
                string quest;
                bool trueFalse;
                string[] ss = line.Split('(');
                if (ss.Length == 2)
                {
                    Console.WriteLine(ss[0] + "\n" + ss[1]);
                    quest = ss[0];
                    trueFalse = ss[1][0] == 'Д' ? true : false;
                    Add(quest, trueFalse);
                }
            }
        }

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Add(Question question)
        {
            list.Add(question);
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fstream, list);
            fstream.Close();
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fstream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fstream);
            fstream.Close();
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}
