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

        public IndustryConfiguration(string filePath,ProgressBar progressBar, Label label)
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

        public static string ReadString(BinaryReader binaryReader)
        {
            int len = binaryReader.ReadInt32();
            return BytesToString(binaryReader.ReadBytes(len));
        }

        public static string BytesToString(byte[] byte_0)
        {
            byte[] array = new byte[byte_0.Length / 2];
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                byte[] array2 = array;
                int num2 = i;
                array2[num2] |= (byte)(byte_0[num++] << 4);
                byte[] array3 = array;
                int num3 = i;
                array3[num3] |= (byte)(byte_0[num++] >> 4);
            }
            return Encoding.UTF8.GetString(array);
        }

        public int IndustryCount;
        public List<Industry> Industries;
    }
}
