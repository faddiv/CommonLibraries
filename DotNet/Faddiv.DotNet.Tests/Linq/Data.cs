using System;
using System.ComponentModel.DataAnnotations;

namespace Faddiv.DotNet.Linq
{
    public class Data
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Data()
        {

        }

        public Data(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Data other &&
                   Id == other.Id &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
