namespace Run8IndustryConfigEditor
{
    public class Industry
    {
        public Industry(BinaryReader binaryReader, Label label)
        {
            // skip 4 bytes
            binaryReader.ReadInt32();
            Name = IndustryConfiguration.ReadString(binaryReader);
            Application.OpenForms[0].Invoke(delegate {
                label.Text = $"Loading industry {Name}";
            });
            //System.Diagnostics.Debug.WriteLine($"Name: {Name}");
            LocalFreightCode = IndustryConfiguration.ReadString(binaryReader);
            //System.Diagnostics.Debug.WriteLine($"LocalFreightCode: {LocalFreightCode}");
            Tag = IndustryConfiguration.ReadString(binaryReader);
            //System.Diagnostics.Debug.WriteLine($"Tag: {Tag}");
            Unknown = binaryReader.ReadBoolean();
            //System.Diagnostics.Debug.WriteLine($"Unknown: {Unknown}");
            TrackCount = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"TrackCount: {TrackCount}");

            this.Tracks = new List<Track>(TrackCount);

            // load tracks
            for (int i = 0; i < TrackCount; i++)
            {
                Tracks.Add(new Track(binaryReader));
            }

            //System.Diagnostics.Debug.WriteLine($"Loaded {Tracks.Count} tracks for {Name}");

            CarCount = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"CarCount: {CarCount}");

            this.Cars = new List<Car>(CarCount);

            // load cars
            for (var i = 0; i < CarCount; i++)
            {
                Cars.Add(new Car(binaryReader));
            }

            //System.Diagnostics.Debug.WriteLine($"Loaded {Cars.Count} cars for {Name}");
        }
        public string Name { get; set; }
        public string LocalFreightCode { get; set; }
        public string Tag { get; set; }
        public bool Unknown { get; set; }
        public int TrackCount { get; set; }
        public List<Track> Tracks;
        public int CarCount { get; set; }
        public List<Car> Cars;
    }
}
