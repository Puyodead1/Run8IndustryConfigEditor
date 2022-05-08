using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run8IndustryConfigEditor
{
    public class IndustryConfiguration
    {
        private string filePath;
        private ProgressBar progressBar;
        private Label label;
        public int IndustryCount;
        public List<Industry> Industries;

        public IndustryConfiguration(string filePath,ProgressBar progressBar, Label label)
        {
            this.filePath = filePath;
            this.progressBar = progressBar;
            this.label = label;
            Industries = new List<Industry>();

            LoadFile();
        }

        /**
         * Loads a configuration file
         */
        private void LoadFile()
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    // skip 4 bytes
                    binaryReader.ReadInt32();
                    // read number of industries
                    IndustryCount = binaryReader.ReadInt32();
                    Application.OpenForms[0].BeginInvoke(delegate {
                        progressBar.Maximum = IndustryCount;
                    });
                    //System.Diagnostics.Debug.WriteLine($"IndustryCount: {IndustryCount}");
                    this.Industries = new List<Industry>(IndustryCount);
                    for (int i = 0; i < IndustryCount; i++)
                    {
                        Industries.Add(new Industry(binaryReader, label));
                        Application.OpenForms[0].BeginInvoke(delegate {
                            progressBar.PerformStep();
                        });
                    }

                    //System.Diagnostics.Debug.WriteLine($"Loaded {Industries.Count} industries");
                }
            }
        }

        public void SaveFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    // the first 4 bytes are skipped
                    binaryWriter.Write(0);
                    binaryWriter.Write(Industries.Count);
                    foreach (Industry industry in Industries)
                    {
                        industry.Save(binaryWriter);
                    }

                    binaryWriter.Close();
                    fileStream.Close();
                }
            }

            MessageBox.Show("File has been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /**
         * Custom function for reading strings
         */
        public static string ReadString(BinaryReader binaryReader)
        {
            int len = binaryReader.ReadInt32();
            return BytesToString(binaryReader.ReadBytes(len));
        }

        public static void WriteString(BinaryWriter writer, string str)
        {
            byte[] bytes = StringToBytes(str);
            writer.Write(bytes.Length);
            writer.Write(bytes);
        }

        public static string BytesToString(byte[] byte_0)
        {
            byte[] array = new byte[byte_0.Length / 2];
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] |= (byte)(byte_0[num++] << 4);
                array[i] |= (byte)(byte_0[num++] >> 4);
            }

            return Encoding.UTF8.GetString(array);
        }

        public static byte[] StringToBytes(string str)
        {
            byte[] byte_0 = Encoding.UTF8.GetBytes(str);
            byte[] array = new byte[byte_0.Length * 2];
            int num = 0;
            for(int i = 0; i < byte_0.Length; i++)
            {
                array[num++] |= (byte)(byte_0[i] >> 4);
                array[num++] |= (byte)(byte_0[i] << 4);
            }

            return array;
        }
    }
}
