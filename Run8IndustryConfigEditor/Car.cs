namespace Run8IndustryConfigEditor
{
    public class Car
    {
        
        public Car(BinaryReader binaryReader)
        {
            Num = binaryReader.ReadInt32();
            CarType = (ECarType)binaryReader.ReadByte();
            bool_0 = binaryReader.ReadBoolean();
            Time = binaryReader.ReadInt32();
            Capacity = binaryReader.ReadInt32();
            DestinationCount = binaryReader.ReadInt32();
            this.Destinations = new List<string>(DestinationCount);
            for (int i = 0; i < DestinationCount; i++)
            {
                Destinations.Add(IndustryConfiguration.ReadString(binaryReader));
            }

            DefList = new List<string>();
            if (Num >= 2)
            {
                Num2 = binaryReader.ReadInt32();
                for (int j = 0; j < Num2; j++)
                {
                    DefList.Add(IndustryConfiguration.ReadString(binaryReader));
                }
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Num);
            writer.Write((byte)CarType);
            writer.Write(bool_0);
            writer.Write(Time);
            writer.Write(Capacity);
            writer.Write(DestinationCount);
            foreach(string d in Destinations)
            {
                IndustryConfiguration.WriteString(writer, d);
            }

            writer.Write(Num2);
            foreach(string d in DefList)
            {
                IndustryConfiguration.WriteString(writer, d);
            }
        }

        private int Num;
        private int Num2;
        public ECarType CarType;
        public bool bool_0;
        public int Time;
        public int Capacity;
        public int DestinationCount;
        public List<string> Destinations;
        private List<string> DefList;
    }
}
