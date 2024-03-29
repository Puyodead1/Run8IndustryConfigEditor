﻿namespace Run8IndustryConfigEditor
{
    public class Track
    {
        public Track(BinaryReader binaryReader)
        {
            // skip 4 bytes
            binaryReader.ReadInt32();
            Prefix = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"Prefix: {Prefix}");
            Section = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"Section: {Section}");
            Node = binaryReader.ReadInt32();
            //System.Diagnostics.Debug.WriteLine($"Node: {Node}");
        }

        public void Save(BinaryWriter writer)
        {
            // write skip bytes
            writer.Write(0);
            writer.Write(Prefix);
            writer.Write(Section);
            writer.Write(Node);
        }

        public int Prefix { get; set; }
        public int Section { get; set; }
        public int Node { get; set; }
    }
}
