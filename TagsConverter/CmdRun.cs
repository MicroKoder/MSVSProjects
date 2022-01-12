using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TagsConverter
{
    class CmdRun : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //   throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
              
                string[] inData= File.ReadAllLines(openFile.FileName);

                List<string> outUserData = new List<string>(); //теги из User
                List<string> outTagsData = new List<string>(); //теги из базы
                foreach (string line in inData)
                {
                    string[] tags = line.Split(' ');
                    foreach (string tag in tags)
                    {
                        if (tag.StartsWith("Fix32."))
                            outTagsData.Add(tag);

                        if (tag.StartsWith("User."))
                            outUserData.Add(tag);

                    }
                }

                string[] outUserUnique = outUserData.Distinct().ToArray();
                string[] outTagsUnique = outTagsData.Distinct().ToArray();

                openFile.FileName = "";
                System.Windows.MessageBox.Show(outUserUnique.Count().ToString() + '\n' + outTagsUnique.Count().ToString());
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                {
                    File.WriteAllLines(saveFile.FileName, outTagsUnique.ToArray());
                    //System.Windows.MessageBox.Show(outTagsData.Count.ToString() + " тегов");
                }

                saveFile.ShowDialog();

                if (saveFile.FileName != "")
                {
                    File.WriteAllLines(saveFile.FileName, outUserUnique.ToArray());
                 //   System.Windows.MessageBox.Show(outUserData.Count.ToString() + " user tags");
                }
            }

            
        }
    }
}
