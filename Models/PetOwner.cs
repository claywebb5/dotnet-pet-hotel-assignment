using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner {
        // id is already recognized as SERIAL and as the Primary KEY
        public int id{get; set;}
        // Required is an attribute that prevents the user from leaving the input blank
        // similar to NOT NULL in SQL
        [Required]
        public string name{get; set;}
        public string email{get; set;}

    }
}
