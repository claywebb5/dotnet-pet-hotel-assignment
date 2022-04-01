using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType 
    {
        Poodle, // Index number is: 0
        Shepard, // Index number is: 1
        Terrier, // Index number is: 2
        GreatDane, // Index number is: 3
        Spaniel // Index number is: 4
    }
    public enum PetColorType 
    {
        Black, // Index number is: 0
        TriColor, // Index number is: 1
        Spotted, // Index number is: 2
        White, // Index number is: 3
        Stripped // Index number is: 4
    }
    public class Pet 
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime checkIn {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType type {get; set;}

        // [JsonConverter(typeof(JsonStringEnumConverter))]
        // public PetColorType type {get; set;}

        [ForeignKey("ownedBy")]
        public int ownedById {get; set;}

        public PetOwner ownedBy {get; set;}
    }
}
