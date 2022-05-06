namespace Run8IndustryConfigEditor
{
    internal class Car
    {
        public Car(BinaryReader binaryReader)
        {
            int num = binaryReader.ReadInt32();
            CarType = (ECarType)binaryReader.ReadByte();
            //System.Diagnostics.Debug.WriteLine($"CarCount: {CarType}");
            bool_0 = binaryReader.ReadBoolean();
            //System.Diagnostics.Debug.WriteLine($"bool_0: {bool_0}");
            Time = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"Time: {Time}");
            Capacity = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"Capacity: {Capacity}");
            DestinationCount = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"DestinationCount: {DestinationCount}");
            this.Destinations = new List<string>(DestinationCount);
            for (int i = 0; i < DestinationCount; i++)
            {
                string d = IndustryConfiguration.ReadString(binaryReader);
                Destinations.Add(d);
                //System.Diagnostics.Debug.WriteLine($"d: {d}");
            }
            //System.Diagnostics.Debug.WriteLine($"Loaded {Destinations.Count} destinations");
            if(num >= 2)
            {
                int num2 = binaryReader.ReadInt32();
                //System.Diagnostics.Debug.WriteLine($"num2: {num2}");
                for (int j = 0; j < num2; j++)
                {
                    //System.Diagnostics.Debug.WriteLine($"Unknown String j{j}: {IndustryConfiguration.ReadString(binaryReader)}");
                }
            }
        }

        public int Num { get; set; }
        public ECarType CarType { get; set; }
        public bool bool_0 { get; set; }
        public int Time { get; set; }
        public int Capacity { get; set; }
        public int DestinationCount { get; set; }
        public List<string> Destinations;
    }
}
